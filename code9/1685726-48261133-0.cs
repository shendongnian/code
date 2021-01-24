    public async Task<string> ReceiveData()
    {
        byte[] buffer = new byte[30];
        try
        {
            while (true)
            {
                if(_inputStream.IsDataAvailable())
                {
                    int read = await _inputStream.ReadAsync(buffer, 0, buffer.Length);
                    if (read <= 0)
                    {
                        return null;
                    }
                    char[] result = Encoding.ASCII.GetChars(buffer);
                    if (!result[0].Equals("\0"))
                    {
                        return result[0].ToString();
                    }
                }
            }
        }
        catch (Exception)
        {
            // Não implementado
        }
        return null;
    }
