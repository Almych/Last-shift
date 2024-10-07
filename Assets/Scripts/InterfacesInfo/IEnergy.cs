using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnergy 
{
    public abstract float  ChangeEnergyValue(float value);

    public abstract float FillEnergy();
}
