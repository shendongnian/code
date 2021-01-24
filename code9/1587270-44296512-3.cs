    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = Instantiate(myPrefab) as Rigidbody;
            rb.AddForce(new Vector3(0, 500, 0));
    
            GameObject obj = rb.gameObject;
            UnityEngine.Debug.Log("Attached Object: " + obj.name);
        }
    }
