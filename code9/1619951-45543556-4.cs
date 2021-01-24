    {
    private bool shortjump = false;
    private bool checkphase = false;
    private bool hitground = false;
    private Rigidbody player = new Rigidbody();
    private bool jumping = false;
    Vector3 sharedjumpforce = new Vector3();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
         {
            Initialjump();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (jumping)
            {
                shortjump = true;
            }
        }
            if (jumping)
        {
            if (hitground)
            {
                jumping = false;
            }
        }
    }
    
    void Initialjump()
    {
        if (jumping = false)
        {
            checkphase = true;
            jumping = true;
            player.AddForce(sharedjumpforce);
            Invoke("Standardorcontrolledjump", 0.2f);
        }
    }
    void Standardorcontrolledjump()
    {
        checkphase = false;
        if (shortjump)
        {
        }
        else
        {
        }
    }
}
