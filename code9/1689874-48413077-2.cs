    void RFunction(bool? proceed = null)
    {
        if ( !proceed.HasValue ) {
            proceed = AskUser();
        }
        if (proceed.Value && other tests)
        {
            RFunction(proceed);
        }
    }
