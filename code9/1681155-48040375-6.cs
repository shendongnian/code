    string testData = @"<Configuration>
                                    <Cameras>
                                        <Camera Name =""Camera1"" Url = ""Camera1"" Width = ""600"" Height = ""800"" />       
                                        <Camera Name = ""Camera2"" Url = ""Camera2"" Width = ""600"" Height = ""800"" />
                                    </Cameras>
                                </Configuration>";
                
                XDocument xdc = XDocument.Parse(testData);
                var arrNames = xdc.Root
                    .Descendants("Camera")
                    .Select(e => e.Attribute("Name")).ToArray();
