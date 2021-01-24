     void Update(){
         float speed = 3.0f;
         float xRot = speed * Input.GetAxis("Vertical");
         float yRot = speed * Input.GetAxis("Horizontal");
         transform.Rotate(xRot, yRot, 0.0f);
      }
