    void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.CompareTag ( "Pick Up"))
            {
                // How it can know which one of the object in the prefab that tagged to "Pick Up" is selected ? and how can make it disabled to be effected by the ball in the second time after the collide ?
                count = count + 1;
                SetCountText ();
                Destroy(other); // Add this...
            }
        }
