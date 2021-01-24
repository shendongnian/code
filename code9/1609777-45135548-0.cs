    public void Damage(int damageAmount)
        {
            //subtract damage amount when Damage function is called
            currentHealth -= damageAmount;
    
            //Check if health has fallen below zero
            if (currentHealth <= 0)
            {
                //if health has fallen below zero, deactivate it
                PlayerLife.ObjectsInRange.Remove(gameObject); 
                gameObject.SetActive(false); //***Over here***
    
            }
        }
