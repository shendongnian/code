    public Text winText;
    private bool FinishLine = false;
    
    void Start()
    {
        FinishLine = false;
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            FinishLine = true;
            winText.text = "You Win";
        }
    }
