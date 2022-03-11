using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public PlayerInventoryController inventoryController;
    public WeaponGenerator generator;

    void Start()
    {
        inventoryController.e_WeaponRequest.AddListener(generator.GenerateWeapon);
    }
}
