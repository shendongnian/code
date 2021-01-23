    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            CancelInvoke("DestroySelf");
            Invoke("DestroySelf", reInitializeLifeOfLine);
        }
    }
     
    void DestroySelf () {
        Destroy(gameObject);
    }
