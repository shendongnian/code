    public GameObject bulletPrefab;
    void functionCalledVeryOften()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Create new Bullet each time
            Rigidbody bullet = Instantiate(bulletPrefab, new Vector3(0, 0, 0), Quaternion.identity) as Rigidbody; 
            //Shoot Bullet
            bullet.velocity = transform.forward * 50;
            Destroy(myObject,10f);
        }
    }
