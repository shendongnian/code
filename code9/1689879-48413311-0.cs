    void RFunction(bool askUser = true)
    {
        if (otherTests && (!askUser || AskUser()))
        {
            RFunction(false);
        }
    }
    
