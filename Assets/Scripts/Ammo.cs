using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: ammo is current on the individuals weapons. May be better stored in weapon system.
// rename to weapon


public class Ammo : MonoBehaviour
{
    [SerializeField] List<Mapping> currentAmmo;

    [System.Serializable]
    class Mapping
    {
        public AmmoType type;
        public int ammo;
    }

    public int GetCurrentAmmo(AmmoType type)
    {
        Mapping mapping = GetMappingForType(type);
        return mapping.ammo;
    }

    public void ReduceAmmo(AmmoType type)
    {
        if (GetCurrentAmmo(type) <= 0)
        {
            Debug.Log("Out of Ammo");
            // Play the 'no ammo' sound
            return;
            
        }
        else
        {
            GetMappingForType(type).ammo --;
        }
    }

    public void IncreaseAmmo(AmmoType type, int ammoAmount)
    {
        GetMappingForType(type).ammo += ammoAmount;
    }

    private Mapping GetMappingForType(AmmoType type)
    {
        foreach (var item in currentAmmo)
        {
            if (item.type == type) return item;
        }

        var newSlot = new Mapping();
        newSlot.type = type;
        currentAmmo.Add(newSlot);

        return newSlot;
    }
}
