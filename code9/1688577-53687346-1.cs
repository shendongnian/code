     public void SendToOne(string id,string message)
        {
            foreach (Socket s in clients)
            {
                if (s.Handle.ToString() == id)
                {
                    Send(s, message);
                }
            }
        }
