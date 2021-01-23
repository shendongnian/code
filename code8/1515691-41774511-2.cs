        private void UDP_Single(object sender, Nequeo.Net.Sockets.IUdpSingleServer server, byte[] data, IPEndPoint endpoint)
        {
            string request = System.Text.Encoding.Default.GetString(data);
            if (request.ToLower().Contains("connect"))
                // Add the new client.
                _clients.GetOrAdd(endpoint, server);
            if (request.ToLower().Contains("disconnect"))
            {
                Nequeo.Net.Sockets.IUdpSingleServer removedServer = null;
                // Remove the existing client.
                _clients.TryRemove(endpoint, out removedServer);
            }
        }
