    public string Put(string id, [FromBody]string filepath) //pass  two parameters
            {
                string b = "The id and model id are not equal.";
                if (id == "1")
                {             
                    FileStream fs = File.OpenRead(filepath);               
                        byte[] byt = new byte[fs.Length];
                        UTF8Encoding temp = new UTF8Encoding(true);
                        while (fs.Read(byt, 0, byt.Length) > 0)
                        {
                           b=temp.GetString(byt);//read the content from myfile.txt
                        // The operation about uploading a blob .........
                        }
                    return b;               
                }
                return b;
            }
