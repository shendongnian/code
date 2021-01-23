    while (!done)
        {
            done = true;
            try
            {
                FileStream fileStream;
                if (File.Exists(path))
                {
                    fileStream = File.Open(path, FileMode.Append);
                }
                else
                {
                    fileStream = File.Open(path, FileMode.OpenOrCreate);
                }
                if (fileStream.Length == 0)
                {
                    //write textA
                }
                else
                {
                    //write textB
                }
                fileStream.Close();
                
            }
            catch (IOException ex)
            {
                done = false;
                
            }
        }
