using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected ParticleSystem bulletsPS;
    [SerializeField] protected float loopTime;
    [SerializeField] protected float ammoUsage;
    protected float timer;

    [SerializeField] protected AmmoHolder ammoHolder;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (timer < 0f && ammoHolder.ammo >= ammoUsage)
        {
            bulletsPS.Play();
            timer = loopTime;

            ammoHolder.ammo -= ammoUsage;
        }
    }
}
