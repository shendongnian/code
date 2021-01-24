    void RFunction(bool proceed = false)
    {
        if (proceed && other tests)
        {
            // We have to ask here because we only ask if (other tests)
            proceed = AskUser();
            RFunction(proceed);
        }
    }
