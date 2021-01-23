    using UnityEngine;
    using UnityEngine.UI;
    
    public class PlayerHealth : MonoBehaviour
    {
        public static float Health;
        public static float maxHealth = 100;
    
        private Text healthText;
    
    
        void Start()
        {
            healthText = GameObject.FindGameObjectWithTag("HealthPoints").GetComponent<Text>();
    
            //Make it full 100% health on start
            Health = maxHealth;
            RefreshHealthBar();
        }
    
    
    
        public void TakeDamage(float damage)
        {
            Health -= damage;
            RefreshHealthBar();
    
            if (Health <= 0)
                Die();
        }
    
        public void Die()
        {
            Health = 0;
            RefreshHealthBar();
    
            //TODO: Your code
        }
    
        void RefreshHealthBar()
        {
            healthText.text = "HEALTH: " + Health;
        }
    }
