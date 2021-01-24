    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        print(currentHealth);// will show in terminal if thats what you are asking
        if (currentHealth <= 0)
        {
            PlayerLifeCollider.instance.ObjectsInRange.Remove(gameObject);
            DestroyZombie();
        }
    }
