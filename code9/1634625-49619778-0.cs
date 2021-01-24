                    using (var client = new WebClient())
                    {
                        bytes = await client.DownloadDataTaskAsync(Url);
                        Source = ImageSource.FromStream(() => new MemoryStream(bytes));
                    }
                
