    private void OnCollisionEnter2D(Collision2D otherCollision)
        {
            if (otherCollision.gameObject.tag == "Projectile")
            {
                injures++;
    
                if (injures >= MAX_INJURES)
                {
                    injures = 0;
                    canPatrol = false;
                    GetComponent<AudioSource>().Play();
    
                    if(fireCoroutine != null)   StopCoroutine (fireCoroutine);
                    if(patrolCoroutine != null) StopCoroutine (patrolCoroutine);
    
                    movementCoroutine = StartCoroutine (DoMovementCoroutine());
                }
            }
        }
