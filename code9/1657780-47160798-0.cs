     try
            {
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream))
                {
                    while (true)
                    {
                        var data = await reader.ReadLineAsync();
                        if (string.IsNullOrEmpty(data))
                        {
                            break;
                        }
                        DatabaseFix(data);
                    }
                }
            }
            catch (Exception ex)
            {
                new LogWriter(ex.ToString());
            }
