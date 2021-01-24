    Wizard wizard;
    ...
    public void click()
    {     
        if (wizard == null)
        {
            // do something
            wizard = new Wizard();
            wizard.Closing += (sender, args) =>
                                {
                                    wizard = null;
                                };
            wizard.Show();
        }
    ...
