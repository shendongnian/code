    void Update(){
        int speed = 5;
        if (Input.GetKeyDown(KeyCode.W)) {
           this.transform.position += new Vector2(0,speed); 
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            this.transform.position += new Vector2(0,-speed);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            this.transform.position += new Vector2(speed,0);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            this.transform.position += new Vector2(-speed,0);
        }   
    }
