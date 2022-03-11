using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WeaponInput : MonoBehaviour
{
    public KeyCode shootInput;
    public KeyCode reloadInput;
    public KeyCode changeToPreviousWeapon;
    public UnityEvent OnShoot;
    public UnityEvent OnStopShooting;
    public UnityEvent OnReload;
    public UnityEvent OnChangeToPreviousWeapon;
    private void Start()
    {
        
    }
    void Update()
    {
        PlayerInput();
    }
    void PlayerInput()
    {
        if (Input.GetKeyDown(changeToPreviousWeapon))
        {
            OnChangeToPreviousWeapon.Invoke();
        }
        if (Input.GetKeyDown(reloadInput))
        {
            OnReload.Invoke();
        }
        else if (Input.GetKey(shootInput))
        {
            OnShoot.Invoke();
        }
        else if (Input.GetKeyUp(shootInput))
        {
            OnStopShooting.Invoke();
        }
    }
}
