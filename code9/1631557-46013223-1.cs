    public void ActionRunner(Action param)
    {
        param();
    }
    public void someFumction()
    {
        ActionRunner(() =>
        {
            // Code goes here
        });
    }
