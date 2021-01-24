     StreamReader sr = new StreamReader(fileNameAndPath);
        string line;
                    try
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if(line == null || line == "")
                            {
                                MessageBox.Show(line);
                            }
                            sr.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Got empty line while reading a file");
                    }
