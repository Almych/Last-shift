using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour, IEnergy
{
    public  event EventHandler<float> OnEnergyChanged;
    public static Action EnergyFlow;
    private float currValue;
    private const float energyLoose = -3f;
    private const float maxEnergy = 100f;
    private const float coolDown = 2f;
    public float CurrValue
    {
        get => currValue;
       private set
        {
            currValue = Mathf.Clamp(value, 0, maxEnergy);
            OnEnergyChanged?.Invoke(this, currValue);
        }
    }
    
    
    private void Start()
    {
        ChangeEnergyValue(maxEnergy);
    }

    private void OnEnable()
    {
        EnergyFlow += ChangeHandler;
    }

    private void OnDisable()
    {
        EnergyFlow -=  ChangeHandler;
    }

    private void ChangeHandler()
    {
        ChangeEnergyValue(energyLoose);
    }


    public float ChangeEnergyValue(float value)
    {
        CurrValue += value / maxEnergy;
        return CurrValue;
    }

    public float FillEnergy()
    {
       return ChangeEnergyValue(maxEnergy);
    }
}
