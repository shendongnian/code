    void Update(){
        int d = 0;
        int speed = 5;
        if (Input.GetKeyDown(KeyCode.W)) {
           d=90; 
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            d = 270;
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            d = 0;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            d=180;
        }
        this.transform.position += new Vector3((int)(speed * Mathf.Sin(d * Mathf.Deg2Rad)), 0, (int)(speed * Mathf.Cos(d * Mathf.Deg2Rad)));
    }
