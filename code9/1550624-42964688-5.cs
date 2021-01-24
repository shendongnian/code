    void OnCollisionEnter(Collision bol)
    {
        if (bol.gameObject.CompareTag("blueBall"))
        {
            lives = lives - 1;
            Debug.Log("Collided red");
        }
        else if (bol.gameObject.CompareTag("greenBall"))
        {
            lives = lives - 2;
            Debug.Log("Collided green");
        }
    
        else if (bol.gameObject.CompareTag("blackBall"))
        {
            lives = lives - 3;
            Debug.Log("Collided black");
        }
    }
