using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Enemy
{
    public abstract class EnemyAbstract : MonoBehaviour
    {
        public float maxHealth;
        public float damage;
        public float moveSpeed;
        public float expDrop;
        public bool isElite;
    
        protected float currentHealth;
        protected bool isDeath;
        protected bool isFrozen;
        protected Rigidbody2D rb;
    
        public virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            transform.tag = "Enemy";
            currentHealth = maxHealth;
            isFrozen = false;
        }
    
        public virtual void FixedUpdate()
        {
            MoveTowardPlayer();
        }
    
        public virtual void TakeDamage(float amount)
        {
            var temp = currentHealth - Mathf.Max(amount, 0);
            currentHealth = Mathf.Clamp(temp, 0, maxHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    
        public virtual void Die()
        {
            Destroy(this.gameObject);
        }
    
        protected virtual void MoveTowardPlayer()
        {
            if (isFrozen) return;
            Vector2 direction = PlayerMovement.Singleton.GetCurrentPlayerPosition() - (Vector2)transform.position;
            rb.velocity = moveSpeed * direction.normalized * Time.fixedDeltaTime;
        }
    
        public virtual void Frozen()
        {
            isFrozen = true;
            rb.velocity = Vector2.zero;
        }
    }
}

