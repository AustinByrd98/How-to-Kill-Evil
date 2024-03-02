using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameWinScript : MonoBehaviour
{
    public Damageable bossHealth;
    public GameObject gameWinScreen;

    // Update is called once per frame
    void Update()
    {
        if( bossHealth.Health <= 0)
        {
            gameWinScreen.SetActive(true);
        }
        
    }

    public void gameWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
