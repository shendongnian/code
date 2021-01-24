    public float health=500f;
    public GameObject gun;
    
    void OnTriggerEnter2D(Collider2D collider){
    BulletScript bullet = collider.gameObject.GetComponent<BulletScript> ();
    
        if (bullet) {
            health -= bullet.getdamage ();
            bullet.hit ();
            Handheld.Vibrate();
    
            if (health <= 0) {
                GetComponent<Animator> ().SetBool ("deadBool", true);
                GetComponent<Animator> ().SetTrigger ("deadTrigger");
                ExecuteAfterTime (1f);                
            }
        }
    }
    IEnumerator ExecuteAfterTime(float time){
        yield return new WaitForSeconds (time);
        
        //destroying gun only
        Destroy (gun);
        
        //manually destroying all of childre
        GameObject child = gameObject.GetComponentInChildren<> (gameObject);
        foreach(var entry in child )
        {
            Destroy(entry);
        }
        
        Destroy (gameObject);
        
    }
