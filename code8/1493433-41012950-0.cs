            const int MAXVALUEPACKET = 5;
            async Task process()
            {
                while (true)
                {
                    var actionBuffer = await ReadFromStreamAsync();
                    byte type = actionBuffer[0];
                    int value = 0;
                    if (type > 0)
                    {
                        byte[] valueBytes = { actionBuffer[4], actionBuffer[3], actionBuffer[2], actionBuffer[1] };
                        value = BitConverter.ToInt32(valueBytes, 0);
                        CommonVariables.RawMessages.Add(new KeyValuePair<byte, int>(type, value));
                        OnHandler();
                    }
                }
            }
            async Task<byte[]> ReadFromStreamAsync()
            {
                await s.ReadAsync(buf, 0, MAXVALUEPACKET);
                return buf;
            }
