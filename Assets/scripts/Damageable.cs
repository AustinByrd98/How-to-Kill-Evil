using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{

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

    private bool isInvincible;
    private float timeSinceHit = 0;
    public float invincibleTimer = .25f;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Hit(float damage)
    {
        if (IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
            }

            timeSinceHit += Time.deltaTime;
        }

        Hit(10);
    }

}
