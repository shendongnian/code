    public Command SendCommand
    {
        get
        {
            return new Command<Entry>((obj) => //obj here means the parameters we're sending I.E: the entry we set it in the page.
            {
                //The code you want to execute
                Entry entry = obj;
                entry.Focus();
            });
        }
    }
