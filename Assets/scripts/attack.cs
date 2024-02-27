using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public float attackDamage = 2f;
    public Vector2 knockBack = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {

            Vector2 finalKnockback = transform.parent.localScale.x > 0 ? knockBack : new Vector2(-knockBack.x, knockBack.y);
            damageable.Hit(attackDamage, finalKnockback);
            //bool gotHit = damageable.Hit(attackDamage, finalKnockback);

            //if (gotHit)
            //{ 

            //    Debug.Log(collision.name + "damage dealt = " + attackDamage);

            //}
           
        }
    }

}
