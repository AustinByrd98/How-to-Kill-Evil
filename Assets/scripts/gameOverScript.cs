using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    [SerializeField]
    public Damageable damageable;
    public GameObject gameOver;



    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (damageable.Health <= 0)
        {
            gameOver.SetActive(true);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
