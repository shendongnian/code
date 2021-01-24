		List<string> lines = new List<string>();
            List<string> lines2 = new List<string>();
            try
            {
                StreamReader reader = new StreamReader(System.IO.File.OpenRead(pad));
                StreamReader read = new StreamReader(System.IO.File.OpenRead(pad2));
                string line;
                string line2;
                while ((line = reader.ReadLine()) != null && (line2 = read.ReadLine()) != null)
                {
                    string[] split = line.Split(Convert.ToChar(seperator));
                    string[] split2 = line2.Split(Convert.ToChar(seperator));
                    if (line.Contains(seperator) && line2.Contains(seperator))
                    {
                        if (split[1] != split2[1])
                        {
                            //It is not the same
                        }
                        else
                        {
                            //It is the same
                            
                        }
                    }
                }
                reader.Dispose();
                read.Dispose();
            }
            catch
            {
            }
