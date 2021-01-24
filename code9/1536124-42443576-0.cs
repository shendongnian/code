    string error = string.Empty;
    bool success = false;
    int tries = 5;
    
    try
    {
        // there is always a chance that the port is open
        // if trying some operations back-to-back
        // give it a few extra tries if necessary
        for (int i = tries; i > 0; --i)
        {
            try
            {
                if (!this.port.IsOpen)
                {
                    this.port.PortName = value;
                    success = true;
                    break;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                error += e.Message;
            }
        }
    }
    finally
    {
        if (!success)
        {
            this.log.Error(error);
        }
    }
