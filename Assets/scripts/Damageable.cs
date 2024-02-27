using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<float, Vector2> damageableHit; 
    Animator animator;
    [SerializeField]
    private float _maxHealth;

    public float MaxHealth
    {
        get
        {
            return _maxHealth;

        }

        set { _maxHealth = value; }
    }

    [SerializeField]
    private float _health;

    public float Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;

            if(_health <= 0)
            {
                IsAlive = false;

            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;
   

    public bool IsAlive
    {
        get { return _isAlive; }
        private set
        {
            _isAlive = value;
            animator.SetBool("IsAlive", value);
            Debug.Log("IsAlive is set at " + value);

        }
    }

    public bool LockVel { get { return animator.GetBool(AnimationStrings.lockVel); } private set { animator.SetBool(AnimationStrings.lockVel, value); } }

    private bool isInvincible;
    private float timeSinceHit = 0;
    public float invincibleTimer = .25f;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public bool Hit(float damage, Vector2 knockBack)
    {
        if (IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;

            animator.SetTrigger(AnimationStrings.hit);
            damageableHit?.Invoke(damage, knockBack);

            LockVel = true;

            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            if(timeSinceHit > invincibleTimer)
            {
                isInvincible = false;
                timeSinceHit = 0;
                LockVel = false;
            }

            timeSinceHit += Time.deltaTime;
        }

       
    }

    public void Heal(float healthRestored)
    {
        Health += healthRestored;
    }

}
