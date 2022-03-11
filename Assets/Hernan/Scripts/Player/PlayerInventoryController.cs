using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public Inventory inventory;
    public WeaponInput input;
    public Transform weaponParent;
    
    public WeaponRequest e_WeaponRequest = new WeaponRequest();

    bool iHaveWeapon;

    void Start()
    {
        input = GetComponent<WeaponInput>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !iHaveWeapon)
        {
            e_WeaponRequest.Invoke(0, weaponParent, inventory);
            
            Weapon weapon = inventory.primaryWeapon.GetComponent<Weapon>();
            input.OnShoot.AddListener(weapon.Shoot);
            input.OnStopShooting.AddListener(weapon.StopShooting);
            input.OnReload.AddListener(weapon.Reload);
            input.OnChangeToPreviousWeapon.AddListener(weapon.ChangeToPreviousWeapon);
        }
    }
}
