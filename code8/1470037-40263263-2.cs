    void functionCalledVeryOften()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Create new Bullet each time
            GameObject myObject = new GameObject("bullet");
            Rigidbody bullet = myObject.AddComponent<Rigidbody>() as Rigidbody;
            //Shoot Bullet
            bullet.velocity = transform.forward * 50;
            Destroy(myObject);
        }
    }
