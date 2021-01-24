    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.tag == "Wall")
        
            //Store new direction
            Vector3 newDirection = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            //Rotate bullet to new direction
            transform.rotation = Quaternion.LookRotation(newDirection);
            //add velocity to bullet based on new forward vector
            bulletRigidBody.velocity = transform.forward * bulletSpeed;
        
    }
