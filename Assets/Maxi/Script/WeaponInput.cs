using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WeaponInput : MonoBehaviour
{
    public KeyCode shootInput;
    public KeyCode reloadInput;
    public KeyCode changeToBeforeWeapon;
    public UnityEvent OnShoot;
    public UnityEvent OnStopShoot;
    public UnityEvent OnReload;
    public UnityEvent OnChangeToBeforeWeapon;
    void Update()
    {
        PlayerInput();
    }
    void PlayerInput()
    {

        if (Input.GetKeyDown(shootInput))
        {
            OnShoot.Invoke();
        }
        else if (Input.GetKeyUp(shootInput))
        {
            OnStopShoot.Invoke();
        }
        else if (Input.GetKeyDown(reloadInput))
        {
            OnReload.Invoke();
        }
        else if (Input.GetKeyDown(changeToBeforeWeapon))
        {
            OnChangeToBeforeWeapon.Invoke();
        }
    }
}
