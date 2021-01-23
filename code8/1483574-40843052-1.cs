    public override void Init(ContentManager Content)
    {
        base.Init(Content);
    
        dynButton = new DynamicButton("Test", new Vector2(450, 100), Color.White);
        dynButton.Click += SomeoneClicked;
    } 
    
    private void SomeoneClicked(object sender, EventArgs e)
    {
        // Your code here.
    }
