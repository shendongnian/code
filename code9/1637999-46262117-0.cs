    transform.Translate (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
    if (grounded) 
    {
        Debug.Log("Is grounded");
        if (Input.GetButtonDown ("Jump"))
        {
            Debug.Log("Jump clicked");
            rb.AddForce (Vector2.up * jumpSpeed);
            grounded = false;
        }
    }
}
