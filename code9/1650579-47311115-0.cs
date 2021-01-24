    while (bytesRead < 4)
            {
                try
                {
                    bytesRead += await stream.ReadAsync(buffer, bytesRead, buffer.Length - bytesRead);
                }
                catch
                {
                    stream.Close();
                    client.Close();
                    return;
                }
            }
