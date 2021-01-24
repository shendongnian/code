    using (StreamReader strReader = File.OpenText(path))
                {
                    while (!strReader.EndOfStream)
                    {
                        string line = strReader.ReadLine();
                        if (line.Contains("<LOG_x0020_ParityRate>")) {
                            line = strReader.ReadLine();
                            string data_ = getTagText(line);
                            string channelName_ = getTagText( strReader.ReadLine());
                            string sql_ = getTagText( strReader.ReadLine());
                            string idHotel_ = getTagText(strReader.ReadLine());
                            string type_ = getTagText(strReader.ReadLine());
                            
                        }
                        
                    }
                }
