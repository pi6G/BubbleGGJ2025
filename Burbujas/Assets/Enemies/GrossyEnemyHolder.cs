using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrossyEnemyHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;

    [SerializeField] private GameObject winScreen;

    public void EliminateEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy, 3f);

        if (enemies.Count == 0)
        {
            Win();
        }
    }

    private void Win()
    {
        winScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
