        if (Input.GetKey("q"))
        {
            Camera.main.transform.rotation *= Quaternion.Euler(45 , 0, 0);
        }
        if (Input.GetKey("e"))
        {
            Camera.main.transform.rotation *= Quaternion.Euler(-45, 0, 0);
        }
