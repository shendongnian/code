    using (CancellationTokenRegistration ctr = cts.Token.Register(() => cmd.Cancel()))
                {
                    using (var reader = cmd.ExecuteReaderAsync(cts.Token))
                    {
                        dt.Load(reader.Result);
                    }
                }
                //SqlDataReader reader = await cmd.ExecuteReaderAsync(cts.Token);
                //DataTable dt = new DataTable();
                //await Task.Run(() => dt.Load(reader), cts.Token);
