    void Start(){
       playerLifeClass = GameObject.FindGameObjectWithTag("Player")>GetComponent<PlayerLifeClass>();
    }
    public bool Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
        //if health has fallen below zero, deactivate it 
           gameObject.SetActive(false); //***Over here***
           playerLifeClass.RemoveZombie(gameObject);
        }
    }
