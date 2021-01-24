    public GameObject myPrefab;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Instantiate(myPrefab) as GameObject;
            obj.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
        }
    }
