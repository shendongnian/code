    bool isOpen;
    ...
    public void click()
    {     
        if (!isOpen)
        {
            // do something
            wizard = new Wizard();
            wizard.Closing += (sender, args) =>
                                {
                                    isOpen = false;
                                };
            isOpen = true;
            wizard.Show();
        }
    ...
