    string testData = @"<Configuration>
                                <Cameras>
                                    <Camera Name =""Camera1"" Url = ""Camera1"" Width = ""600"" Height = ""800"" />       
                                    <Camera Name = ""Camera2"" Url = ""Camera2"" Width = ""600"" Height = ""800"" />
                                </Cameras>
                            </Configuration>";
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            // testData is your xml string
            using (TextReader reader = new StringReader(testData))
            {
                Configuration result = (Configuration)serializer.Deserialize(reader);
            }
