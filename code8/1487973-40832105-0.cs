    private bool hasCollided = false;
    void OnCollisionEnter(Collision col)
    {
        if(this.hasCollided == true){ return; }
        this.hasCollided = true;
    }
    void LateUpdate()
    {
        this.hasCollided = false;
    }
