using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private Transform weaponPlacementParent;

    private bool[] isWeaponUnlocked;

    private Weapon currentWeapon;

    private void Start()
    {
        currentWeapon = Instantiate(weapons[0]);
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            currentWeapon.Shoot();
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }

    }

    private void SwitchWeapon(int weaponNumber)
    {
        Destroy(currentWeapon.gameObject);
        currentWeapon = Instantiate(weapons[weaponNumber], weaponPlacementParent.position, weaponPlacementParent.rotation);
        currentWeapon.transform.parent = weaponPlacementParent;
        currentWeapon.transform.localPosition = Vector3.zero;
    }
}
