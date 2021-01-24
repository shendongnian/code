            while (keepRunning)
            {
                try
                {
                    TcpClient socket = server.AcceptTcpClient(); //Socket Server accept a new connection and assigned an independent socket client.
                    if (keepRunning)
                        RequestManager.askForRequestAdnRunIt(socket, idLayout); //The Socket Client is attending at the remote endpoint
                }
                catch (Exception ex)
                {
                    log.Error("Se detecto un error en el puerto para atencion de peticiones. ERR: " + ex.Message);
                    log.Error(ex.StackTrace);
                }
            }
