      foreach (string strFileName in Directory.GetFiles(@"D:\\test\","*.txt"))
                {
                    string extension;
                    extension = Path.GetExtension(strFileName);
    
                    if (extension != ".txt")
                        continue;
                    else
                    {
                        //processed the file
                    }
                }  
