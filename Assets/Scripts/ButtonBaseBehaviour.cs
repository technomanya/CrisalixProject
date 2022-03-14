using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBaseBehaviour : MonoBehaviour
{
    public Dropdown colorsDrop;
    public Slider sizeSlider;
    public GameManager GM;
    public Text sizeAmountText;
    public virtual void ButtonOnClick()
    {
        
    }
}
