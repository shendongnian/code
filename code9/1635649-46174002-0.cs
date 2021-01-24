    if (Input.GetKey(KeyCode.W))
        {
            // If the character is not in the air then turn on the walk animation
            if (!isInAir)
            {
                animator.SetBool("Walking", true);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime); //<-- New line
            }
            //transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime); //<-- Removed line
        }
