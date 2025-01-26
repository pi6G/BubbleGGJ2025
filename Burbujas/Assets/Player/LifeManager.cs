using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private float maxLife;
    [SerializeField] private Image lifeBar;
    private float life;

    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject damageScreen;
    void Start()
    {
        life = maxLife;
    }

    public void TakeDamage(float dmgAmount)
    {
        life -= dmgAmount;
        lifeBar.fillAmount = life / maxLife;

        if (life <= 0f)
        {
            Death();
        }

        StartCoroutine(takeDamageVisual());
    }

    private void Death()
    {
        loseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private IEnumerator takeDamageVisual()
    {
        damageScreen.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        damageScreen.SetActive(false);
    }
}
