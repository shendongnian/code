 	public void Update()
    {
        if (Input.GetButtonDown(KeyCode.C))
        {            
            var gameObject = GameObject.Find("..."); // The parent game object to toggle
            gameObject.SetActive(false); //true or false
        }
    }
    
