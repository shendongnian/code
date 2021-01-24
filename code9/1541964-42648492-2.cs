    public static class SocketReader
    {
        // This method will continues read until count bytes are read. (or socket is closed)
        private static void DoReadFromSocket(Socket socket, int bytesRead, int count, byte[] buffer, Action<ArraySegment<byte>> endRead)
        {
            // Start a BeginReceive.
            try
            {
                socket.BeginReceive(buffer, bytesRead, count - bytesRead, SocketFlags.None, (asyncResult) =>
                {
                    // Get the bytes read.
                    int read = 0;
                    try
                    {
                        // if this goes wrong, the read remains 0
                        read = socket.EndReceive(asyncResult);
                    }
                    catch (ObjectDisposedException) { }
                    catch (Exception exception)
                    {
                        Trace.TraceError(exception.Message);
                    }
                    // if zero bytes received, the socket isn't available anymore.
                    if (read == 0)
                    {
                        endRead(new ArraySegment<byte>(buffer, 0, 0));
                        return;
                    }
                    // increase the bytesRead, (position within the buffer)
                    bytesRead += read;
                    // if all bytes are read, call the endRead with the buffer.
                    if (bytesRead == count)
                        // All bytes are read. Invoke callback.
                        endRead(new ArraySegment<byte>(buffer, 0, count));
                    else
                        // if not all bytes received, start another BeginReceive.
                        DoReadFromSocket(socket, bytesRead, count, buffer, endRead);
                }, null);
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.Message);
                endRead(new ArraySegment<byte>(buffer, 0, 0));
            }
        }
        public static void ReadFromSocket(Socket socket, int count, Action<ArraySegment<byte>> endRead)
        {
            // read from socket, construct a new buffer.
            DoReadFromSocket(socket, 0, count, new byte[count], endRead);
        }
        public static void ReadFromSocket(Socket socket, int count, byte[] buffer, Action<ArraySegment<byte>> endRead)
        {
            // if you do have a buffer available, you can pass that one. (this way you do not construct new buffers for receiving and able to reuse buffers)
            // if the buffer is too small, raise an exception, the caller should check the count and size of the buffer.
            if (count > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(count));
            DoReadFromSocket(socket, 0, count, buffer, endRead);
        }
    }
