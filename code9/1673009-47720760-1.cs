     void Update () {
            if (Input.GetKey(KeyCode.C))
            {
                var myObject = gameObject.GetComponent<Renderer>();
                Color currentColor = myObject.material.color;
                if(currentColor == Color.green)
                {
                   myObject.material.color = Color.Red;
                }
                else
                {
                   myObject.material.color = Color.Green;
                }
            }
