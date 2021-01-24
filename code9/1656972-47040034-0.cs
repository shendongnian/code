            var clones = new List<GameObject>();
            GameObject box = null;
            if (Input.GetKeyDown(KeyCode.A))
            {
                box = box_0
            }
            // else if ... box = box_1 ...
            // end of your series of else if
            if (box != null)
            {
                clone = Instantiate(box, transform.position, Quaternion.identity);
                clones.Add(clone);
            }
            box = null;
            //   
            foreach (GameObject clone in clones)
            {
                clone.transform.Translate(Vector3.down * fallspeed * Time.deltaTime, Space.World)
            }
