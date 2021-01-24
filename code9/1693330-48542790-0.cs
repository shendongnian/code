    bool isReset = true;
    public void Update(){
        if(isReset && Input.GetKeyDown(KeyCode.Space){
            if (startPosition == "Right"){
                rbBall.velocity = Vector2.right * speed;
            }else{
                rbBall.velocity = -Vector2.right * speed;
            }
            isReset = false;
        }
    }
    public void Reset (string startPosition)
    {
        transform.position = defaultPos;
        isReset = true;
    }
    void Start(){
        rbBall = GetComponent<Rigidbody2D>();
    }
