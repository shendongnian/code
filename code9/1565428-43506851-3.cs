    using (var streamReader = new StreamReader(filename))
                {
                    string jsonContent = streamReader.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine(jsonContent);
                    var configJson = JsonConvert.DeserializeObject<Configs>(jsonContent,
                        new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
                }
