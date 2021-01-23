        if (Input.GetKey("q"))
        {
            Camera.main.transform.rotation *= Quaternion.Euler(0, 45, 0);
        }
        if (Input.GetKey("e"))
        {
            Camera.main.transform.rotation *= Quaternion.Euler(0, -45, 0);
        }
