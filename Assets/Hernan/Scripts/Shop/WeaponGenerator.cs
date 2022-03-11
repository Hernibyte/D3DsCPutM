using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{
    public List<GameObject> weaponList;

    public void GenerateWeapon(int index, Transform parent, Inventory inventory)
    {
        inventory.primaryWeapon = Instantiate(weaponList[index], parent);
    }
}
