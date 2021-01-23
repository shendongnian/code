        private void CaptureAndSend()
        {
            if (_demux != null)
            {
                // Open the web cam device.
                _demux.OpenDevice("video=Integrated Webcam", true, false);
                byte[] sound = null;
                Bitmap[] image = null;
                long audioPos = 0;
                long videoPos = 0;
                int count = 0;
                KeyValuePair<IPEndPoint, Nequeo.Net.Sockets.IUdpSingleServer>[] clientCol = null;
                // Most of the time one image at a time.
                MemoryStream[] imageStream = new MemoryStream[10];
                int imageStreamCount = 0;
                // Within this loop you can place a check if there are any clients
                // connected, and if none then stop capturing until some are connected.
                while ((_demux.ReadFrame(out sound, out image, out audioPos, out videoPos) > 0) && !_stopCapture)
                {
                    imageStreamCount = 0;
                    count = _clients.Count;
                    // If count has changed.
                    if (_clientCount != count)
                    {
                        // Get the collection of all clients.
                        _clientCount = count;
                        clientCol = _clients.ToArray();
                    }
                    // Has an image been captured.
                    if (image != null && image.Length > 0)
                    {
                        // Get all clients and send.
                        if (clientCol != null)
                        {
                            for (int i = 0; i < image.Length; i++)
                            {
                                // Create a memory stream for each image.
                                imageStream[i] = new MemoryStream();
                                imageStreamCount++;
                                // Save the image to the stream.
                                image[i].Save(imageStream[i], System.Drawing.Imaging.ImageFormat.Jpeg);
                                // Cleanup.
                                image[i].Dispose();
                            }
                            // For each client.
                            foreach (KeyValuePair<IPEndPoint, Nequeo.Net.Sockets.IUdpSingleServer> client in clientCol)
                            {
                                // For each image captured.
                                for (int i = 0; i < imageStreamCount; i++)
                                {
                                    // Send the image to this client.
                                    client.Value.SendTo(imageStream[i].ToArray(), client.Key);
                                    imageStream[i].Seek(0, SeekOrigin.Begin);
                                }
                            }
                            for (int i = 0; i < imageStreamCount; i++)
                                // Cleanup.
                                imageStream[i].Dispose();
                        }
                    }
                }
            }
        }
