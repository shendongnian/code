    public bool TryReadResponse(byte[] buffer, int expectedNumberOfBytes)
    {
        try
        {
            int remaining = expectedNumberOfBytes;
            int offset = 0;
            while (remaining > 0)
            {
                int read = socet.Receive(buffer, offset, remaining, SocketFlags.None);
                if (read == 0)
                {
                    // other side has closed the connection before sending the requested number of bytes
                    return false;
                }
                offset += read;
                remaining -= read;
            }
            return true;
        }
        catch (Exception ex)
        {
            // failure
            return false;
        }
    }
