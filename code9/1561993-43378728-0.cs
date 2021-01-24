    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.SendMessage("damage", 2);
            Destroy(this.gameObject);
        }
    
        //call alarm_enemies function here but once in a level, not every time, it generate
    
        //Send if we have not send this before
        if (!sentOnce)
        {
            sentOnce = true;
            //Alert every enemy
            OnDamaged();
        }
    }
