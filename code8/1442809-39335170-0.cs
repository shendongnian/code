     void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Use"))
        {
            
            if (carTitle == "98")
            {
               SceneManager.LoadScene("NewScene");
            }
        }
        
    }
