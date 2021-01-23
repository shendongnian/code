    using (var clients = new RouterSocket(connStr.Value))
    using (var workers = new DealerSocket())
        {
            workers.Bind("inproc://workers");
                for (var i = 0; i < workerCount; i++)
                {
                    new Thread(Worker).Start();
                }
                var prx = new Proxy(clients, workers);
                prx.Start();
                }
    
    private void Worker()
        {
            using (var socket = new ResponseSocket())
            {
                socket.Connect("inproc://workers");
                while (true)
                {
                     //...
                }
            }
        }
