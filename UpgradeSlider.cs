using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    public void SetValue(float value)
    {
        _slider.value = value;
    }
}
