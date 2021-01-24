    private Button myButton;
    public event EventHandler MyButtonClick
    {
        add { myButton.Click += value; }
        remove { myButton.Click -= value; }
    }
