    void DoStuff(Action action, ExceptionHandler log)
    {
        using(var connction = new SqlConnection(""))
        {
            try
            {
                action();
            }
            catch(Exception e)
            {
                log(e)
            }
        }
    }
