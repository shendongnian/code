    void OnTriggerStay(Collider other) //Runs once per collider that is touching the player every frame
    {
    
        if (other.CompareTag("Player"))
        { //A player is touching the ladder
    
            //I want to get the isGrounded variable or getIsGrounded() function from other's playerScript.     
            if(other.GetComponent<MyScript>().getIsGrounded)
            {
    
            }
    
            if (Input.GetAxis("Vertical") < 0)
            { // Player should go down
                other.transform.Translate(0, -.1f, 0);
            }
            else if (Input.GetAxis("Vertical") > 0) //Player should go up
                other.transform.Translate(0, .1f, 0);
        }
    
    }
