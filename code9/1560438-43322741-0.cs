    while (ServerRunning)
    {
        AsyncHandler handler = delegate(asyncResult)
        {
            //Get the new socket
            Socket socket = myList.EndAcceptSocket(asyncResult);
            //Marshal UI specific code back to the UI thread
            MethodInvoker invoker = delegate()
            {
                listOFClientsSocks.Add(socket);
                listBox1.DataSource = listOFClientsSocks;
                displayText.AppendText("\nConnected");
            };
            listBox1.Invoke(invoker);
            //Call the handler
            tcpHandler();
        }
        IAsyncResult waitResult = myList.BeginAcceptSocket(handler, null);
        //Wait until the async result's wait handle receives a signal
        //Use a timeout to referesh the application every 100 milliseconds
        while (!waitResult.AsyncWaitHandle.WaitOne(100))
        {
            Application.DoEvents();
            if (!ServerRunning)
            {
                break;
            }
        }
    }
