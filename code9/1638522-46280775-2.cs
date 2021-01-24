    // check if we can process this request
    if (l.NumberOfDays < MAX_LEAVES_CAN_APPROVE)
    {
        // process it on our level only
        ApproveLeave(l);
    }
    else
    {
        // if we cant process pass on to the supervisor 
        // so that he can process
        if (Supervisor != null)
        {
            Supervisor.LeaveApplied(this, l);
        }
    }
