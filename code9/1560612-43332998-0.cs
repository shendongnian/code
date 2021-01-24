        public void run()
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            
            log.Info("Starting SocketServer on Port [" + port + "]");
            while (keepRunning)
            {
                try
                {
                    TcpClient socket = server.AcceptTcpClient();
                    if (keepRunning)
                        RequestManager.createRequestForEvalue(socket, idLayout);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    log.Error(ex.StackTrace);
                }
            }
            log.Info("Server Stoped.");
        }
        public static bool createRequestForEvalue(TcpClient socket, int idLayout)
        {
            Request req = null;
            req = new Request(socket,idLayout);
            registerRequest(req.ID,req); //Registra el Request, para su posterior uso.
            // DO NOT CREATE THREADS FOR ATTEND A NEW CONNECTION!!!
            //Task.Factory.StartNew(req.RunForIVR);
            //ThreadPool.QueueUserWorkItem(req.RunForIVR);
            req.startReceiveAsync(); //Recive data in asyncronus way.
            return true;
        }
        public void startReceiveAsync()
        {
            try
            {
                log.Info("[" + id + "] Starting to read the Request.");
                requestBuffer = new byte[BUFFER_SIZE];
                NetworkStream nst = socket.GetStream();
                nst.BeginRead(requestBuffer, 0,BUFFER_SIZE, this.requestReceived, nst);
            }catch(Exception ex)
            {
                log.Error("[" + id + "] There was a problem to read the Request: " + ex.Message);
                RequestManager.removeRequest(id);
                closeSocket();
            }
        }
        public void requestReceived(IAsyncResult ar)
        {
            try
            {   
                message = Encoding.UTF8.GetString(requestBuffer, 0, BUFFER_SIZE);
                log.Info("[" + id + "] Request recived: [" + message +"]");
                RunForIVR();
            }
            catch (Exception ex)
            {
                log.Error("[" + id + "] There was a problem to read the Request: " + ex.Message);
                RequestManager.removeRequest(id);
                closeSocket();
            }
        }
