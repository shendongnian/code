    public OnMousePressCasino onMousePressCasinoBarthender;
    public OnMousePressCasino onMousePressCasinoDoorToStreet;
    
    void Start()
    {
        onMousePressCasinoBarthender.OnAction += MeAction;
        onMousePressCasinoDoorToStreet.OnAction += MeAction;
    }
    
    void MeAction(object sender, MeEventArgs e)
    {
        if(e.Action == 1)
        {
            // do something
        }
        else if (e.Action == 2)
        {
            // do something else.
        }
    }
