    private void Start()
        {
            data.PlatformRigid.useGravity = false; // Disable the gravity to make it stay in the air
        }
    
        private void OnTriggerEnter(Collider col)
        {
            if (!data.Activated) // just do this 1 time 
            {
                if (col.CompareTag("Player")) // just start executing the following code if the colliding object is the player
                {
                    data.Activated = true; // don't execute this code a second time
                    data.PlatformRigid.useGravity = true; // start falling
                }
            }
        }
    
        private void OnCollisionEnter(Collision col)
        {
            if (!col.gameObject.CompareTag("Player"))
            {
                Instantiate(gameObject, data.StartPosition, data.StartRotation); // Create itself at default
                Destroy(gameObject); // Destroy itself
            }
        }
