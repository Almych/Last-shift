using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnergySliderController : MonoBehaviour
{
    [SerializeField] EnergyManager energyManager;
    [SerializeField] private Slider energyBar;

    private void Start()
    {
        energyBar.value = 1;

        energyManager.OnEnergyChanged += EnergyBarUpdate;
    }

    private void OnDisable()
    {
        energyManager.OnEnergyChanged -= EnergyBarUpdate;
    }

    private void EnergyBarUpdate(object sender, float value)
    {
        energyBar.value = value;
    }
}
