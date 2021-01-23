      using (DataWriter writer = new DataWriter(socket.OutputStream))
                        {
                            string len = String.Format("{0:D4}", message.Length);
                            writer.WriteString(len + "" + message);
                            await writer.StoreAsync();
                            await writer.FlushAsync();
                            writer.DetachStream();
    }
