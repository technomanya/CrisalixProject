using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    
    public bool isBallSizeable = true;
    public GameObject ballAttributesUI;
    public Text createButtonText;
    public GameObject stressBall;
    public List<Dropdown> colorDropList;
    public List<Material> colorTextureList;
    public List<Button> mainSizeButtons;
    
    private Dictionary<string, Material> _colorTextureDict = new Dictionary<string, Material>();
    public Dictionary<string, float> MainSizeDict = new Dictionary<string,float>();
    private Vector3 lastSize; 
    void Start()
    {
        colorTextureList.ForEach(color =>
        {
            _colorTextureDict.Add(color.name,color);
        });
        var mainSizeAmount = 1f;
        mainSizeButtons.ForEach(button =>
        {
            MainSizeDict.Add(button.name,mainSizeAmount);
            mainSizeAmount += 1f;
        });
    }

    public void ColorChange(string colorName)
    {
        if (colorName == "Black")
        {
            isBallSizeable = false;
            stressBall.transform.localScale = Vector3.one*5f;
        }
        else
        {
            isBallSizeable = true;
            stressBall.transform.localScale = lastSize;
        }
        stressBall.GetComponent<MeshRenderer>().material = _colorTextureDict[colorName];
    }

    public void SizeChange(float sizeAmount)
    {
        stressBall.transform.localScale = Vector3.one * sizeAmount;
        lastSize = Vector3.one * sizeAmount;
    }

    public void Create()
    {
        var isCanvasOpen = ballAttributesUI.activeInHierarchy;
        ballAttributesUI.SetActive(!isCanvasOpen);
        //stressBall.SetActive(isCanvasOpen);
        if (!isCanvasOpen)
        {
            createButtonText.text = "Create";
            stressBall.GetComponent<MeshRenderer>().material = _colorTextureDict["Default"];
            stressBall.transform.localScale = Vector3.one;
        }
        else
        {
            createButtonText.text = "New Ball";
        }
    }
}
