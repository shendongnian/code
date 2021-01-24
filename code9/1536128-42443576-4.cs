    SerialPort port = null;
    string error = string.Empty;
    bool success = false;
    int tries = 5;
    
    foreach(var name in System.IO.Ports.SerialPort.GetPortNames())
    {
        // try each port until you find an open one
        port.Name = name;
        // there is always a chance that the port is open
        // if trying some operations back-to-back
        // give it a few extra tries if necessary
        for (int i = tries; i > 0; --i)
        {
            try
            {
                // avoid the exception by testing if open first
                if (!port.IsOpen)
                {
                    port.Open();
                    success = true;
                    return;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                // sometimes the exception happens anyway, especially
                // if you have multiple threads/processes banging on the
                // ports
                error += e.Message;
            }
        }
    }
