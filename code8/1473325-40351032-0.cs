    void Update(){
        if(leftJoystick){
            rb.AddRelativeForce(0, 0, 400f, ForceMode.Impulse);
        }
    
        if(noJoystick){
            rb.velocity = rb.velocity * 0.95 * Time.deltaTime;
            //Or: rb.velocity.x
        }
    }
