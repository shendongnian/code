    public void AddHealth(float a)
    {
        if(myhealth == null)
        {
            Debug.Log("myhealth is null !!");
        }
        else
            myhealth.HealEnemy(a);
    }
