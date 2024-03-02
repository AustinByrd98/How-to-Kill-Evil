using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartManager : MonoBehaviour
{
    public Damageable playerHealth;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
     



    //public void Awake()
    //{
    //    playerHealth = GetComponent<Damageable>();
        
    //}
         
    // Update is called once per frame
    void Update()
    { 

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth.Health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }


    }
}
