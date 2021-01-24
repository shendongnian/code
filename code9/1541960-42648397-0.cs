    Vector2 moveDirection = Vector2.zero;
    void Update(){
         CharacterController player = GetComponent<CharacterController>();
         if (player.isGrounded)
         {             
         // constantly move horizontally
         moveDirection.x = valuespeed;
         player.Move(moveDirection * Time.deltaTime);
         }
     }
