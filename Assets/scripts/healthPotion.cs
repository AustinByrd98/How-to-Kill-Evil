using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPotion : MonoBehaviour
{
    //GameObject gameObject;
    public float healthRestored = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.gameObject.GetComponentInParent<Damageable>();
        float heathDef = 0;


        Debug.Log(damageable);
        if(damageable && damageable.IsAlive)
        {
            if (damageable.Health + healthRestored > damageable.MaxHealth)
            {
                heathDef = damageable.MaxHealth - damageable.Health;
                damageable.Heal(heathDef);
                Destroy(gameObject);
                
            } else
            {
                damageable.Heal(healthRestored);
                Debug.Log(collision.name + " healed " + healthRestored);
                Destroy(gameObject);

            }

          
        }
    }
}
