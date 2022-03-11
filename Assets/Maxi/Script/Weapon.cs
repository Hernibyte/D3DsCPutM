﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public float firerate;
    public int actualBullets;
    public int maxBullets;
    public int reloadBullets;
    public float timeReload;
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

    void Update()
    {
        if (myState != State.shooting)
            return;

        Shooting();

    }
    public void Shoot()
    {
        myState = State.shooting;
    }
    void Shooting()
    {
        RaycastHit aux;
        Physics.Raycast(transform.position, Vector3.forward, out aux, distance);
        Instantiate(a, aux.point, Quaternion.identity, null);
    }
    public void StopShooting()
    {
        myState = State.nothing;
    }
    public void Reload()
    {
        myState = State.reloading;

    }
    public void ChangeToPreviousWeapon()
    {

        myState = State.changingWeapon;
    }
}
