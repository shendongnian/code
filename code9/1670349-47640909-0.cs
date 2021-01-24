        public void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();
            if (Connected != null)
            {
                Connected.Invoke(this, new EventArgs());
            }
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            BeginReceive(handler);
            //while (handler.Connected)
            //{
            //    if (queue.TryDequeue(out String data))
            //    {
            //        try
            //        {
            //            SendData(handler, data);
            //        }
            //        catch (Exception ex)
            //        {
            //            throw;
            //        }
            //    }
            //    Thread.Sleep(0);
            //}
        }
        public void BeginReceive(Socket handler)
        {
            StateObject state = new StateObject
            {
                workSocket = handler
            };
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }
        public void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0)
            {
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                content = state.sb.ToString();
                if (queue.TryDequeue(out String data))
                {
                    try
                    {
                        SendData(handler, data);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                //SendData(handler, content);
                Debug.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content);
            }
            BeginReceive(handler);
        }
