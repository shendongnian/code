        public void ReceiveCallback(IAsyncResult ar)
        {
            // Get the client.
            UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;
            IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).e;
            // Get the image.
            Byte[] receiveBytes = u.EndReceive(ar, ref e);
            // Load the image into a stream.
            MemoryStream stream = new MemoryStream(receiveBytes);
            Image image = Image.FromStream(stream);
            
            // Add the image to the picture box.
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = image;
            stream.Dispose();
            // Start a new receive request.
            u.BeginReceive(new AsyncCallback(ReceiveCallback), (UdpState)(ar.AsyncState));
        }
