            while (true)
            {
                using (Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp))
                {
                    connectDone = new ManualResetEvent(false);
                    sendDone =  new ManualResetEvent(false);
                    receiveDone =  new ManualResetEvent(false);
                    client.BeginConnect(remoteEP,
                        new AsyncCallback(ConnectCallback), client);
                    connectDone.WaitOne();
                    string myCommand = "";
                    //Thread.Sleep(100);  
                    // Create a TCP/IP socket.
                    Console.WriteLine("Enter command:");
                    myCommand = Console.ReadLine();
                    if (myCommand == "quit") break;
                    // Send test data to the remote device.
                    Send(client, myCommand + "<EOF>");
                    sendDone.WaitOne();
                    // Receive the response from the remote device.
                    Receive(client);
                    receiveDone.WaitOne();
                    // Write the response to the console.
                    Console.WriteLine("Response received : {0}", response);
                    // Release the socket.
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }
    
