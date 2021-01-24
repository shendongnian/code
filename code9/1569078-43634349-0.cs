    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        EnemiesAlive--;
    
        if (EnemiesAlive <= 0)
        {
            Debug.Log ("LEVEL WON!");
            Invoke("ChangeScene",2f);
        }
    }
    
    void ChangeScene()
    {
        Debug.Log ("Hello");
        loadToScene = 1;
        Destroy(gameObject);
        SceneManager.LoadScene (loadToScene);
    }
