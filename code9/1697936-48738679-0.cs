    Vector3 totalMovement = Vector3.zero;
    if (Input.GetKey(KeyCode.W))
    {
        totalMovement += transform.forward;
    }
    if (Input.GetKey(KeyCode.A))
    {
        totalMovement -= transform.right;
    }
    // To ensure same speed on the diagonal, we ensure its magnitude here instead of earlier
    player.MovePosition(transform.position + totalMovement.normalized * speed * Time.deltaTime);
