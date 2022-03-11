using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public float firerate;
    float firerateCount;
    public int actualBullets;
    public int maxBullets;
    public int reloadBullets;
    public float timeReload;
    float reloadCount;
    public float timeToChangeWeapon;
    public Vector2 recoil;
    public float standardScattering;
    public float actualScattering;
    const float distance = 500f;
    enum State
    {
        nothing, shooting, reloading, changingWeapon, empty
    };
    State myState;


    public GameObject a;
    void OnEnable()
    {
        firerateCount = 0; 
        if(timeReload == 0f)
        {
            timeReload = 0.01f;
            Debug.LogWarning("timeReload value 0, bad idea.. changed to 0.01f");
        }
    }
    void Update()
    {
        if (firerateCount > 0) {  firerateCount -= Time.deltaTime; return; }
        
        if (actualBullets <= 0) myState = State.empty;

        if (myState == State.reloading) { Reloading(); return; }

        if (myState != State.shooting) return;

        Shooting();

    }
    public void Shoot()
    {
        if(myState == State.nothing)
        myState = State.shooting;
    }
    void Shooting()
    {
        RaycastHit aux;
        Physics.Raycast(transform.position, Vector3.forward, out aux, distance);
        Instantiate(a, aux.point, Quaternion.identity, null);
        firerateCount = firerate;
        actualBullets -= 1;
    }
    public void StopShooting()
    {
        if(myState == State.shooting)
        myState = State.nothing;
    }
    public void Reload()
    {
        myState = State.reloading;
        reloadCount = timeReload;
    }
    void Reloading()
    {
        
        if (reloadCount > 0)
        {
            reloadCount -= Time.deltaTime;
        }
        if (reloadCount < timeReload / 2 && actualBullets != maxBullets)
        {
            actualBullets = maxBullets;
        }
        else if (reloadCount < 0 && actualBullets == maxBullets)
        {
            myState = State.nothing;
        }
    }
    public void ChangeToPreviousWeapon()
    {
        if(myState == State.nothing)
        myState = State.changingWeapon;
    }
}
