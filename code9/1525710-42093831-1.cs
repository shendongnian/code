    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.GetComponent<KeyComponent>() != null && other.GetComponent<KeyComponent>().PickedUp)
        {
            SceneManager.LoadScene(2);
        } 
    }
