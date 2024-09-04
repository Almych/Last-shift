using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    enum ItemType
    {
        Holdable,
        Useable
    };


    public void Pick();

    public void Hold(Transform parent);

   
}

public interface IDropable
{
    public void Drop();

}
 
