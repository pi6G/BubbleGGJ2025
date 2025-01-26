using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoHolder : MonoBehaviour
{
    [SerializeField] private float fillingRate;
    public float maxAmmo;
    [HideInInspector] public float ammo;
    [SerializeField] private Image soapBar;

    private void Start()
    {
        ammo = maxAmmo;
    }

    private void Update()
    {
        ammo += Time.deltaTime * fillingRate;
        if (ammo > maxAmmo) ammo = maxAmmo;

        soapBar.fillAmount = ammo / maxAmmo;
    }
}
