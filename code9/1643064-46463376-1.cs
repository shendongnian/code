    float moveSpeed = 0f;
    // modify this to change how your intertia looks like
    float frictionValue = 1f;
    void Update()
    {
      float y = Input.GetAxisRaw("Vertical");
      moveSpeed += y * Time.deltaTime;
      Move();
      moveSpeed = Mathf.Lerp(moveSpeed, 0f, frictionValue * Time.deltaTime); 
    }
    void Move()
    {
      Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
      Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
      Vector2 pos = transform.position;       
      pos += moveSpeed * Time.deltaTime;
      pos.y = Mathf.Clamp(pos.y, min.y, max.y);
      transform.position = pos;       
    }
