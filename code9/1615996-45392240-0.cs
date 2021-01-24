            // Assign as the default value first.
            GetComponent<Image>().sprite = top;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Image>().sprite = topleft; 
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Image>().sprite = topright;
            }
