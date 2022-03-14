using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeButtonModel : ButtonBaseBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ButtonOnClick);
        colorsDrop.onValueChanged.AddListener(delegate {OnColorChange(); });
        sizeSlider.onValueChanged.AddListener(delegate{OnSizeChange();});
    }

    void OnColorChange()
    {
        var index = colorsDrop.value;
        GM.ColorChange(colorsDrop.options[index].text);
    }

    void OnSizeChange()
    {
        if(GM.isBallSizeable)
            GM.SizeChange(sizeSlider.value * 0.1f);
        else
            GM.SizeChange(5f);
        sizeAmountText.text = sizeSlider.value * 0.1f + "cm";
    }
    public override void ButtonOnClick()
    {
        var activeStat = false;
        GM.colorDropList.ForEach(drop =>
        {
            Debug.Log(drop.name+" "+colorsDrop.name);
            activeStat = drop.name == colorsDrop.name;
            
            drop.gameObject.SetActive(activeStat);
        });
        GM.SizeChange(GM.MainSizeDict[gameObject.name]);
        GM.ColorChange(colorsDrop.options[0].text);
    }
}
