        class FileLoader
        {
            public FileLoader()
            {
                if (File.Exists("texter.txt"))
                {
                    List<string[]> vectors = new List<string[]>();
                    StreamReader reader = new StreamReader("texter.txt", Encoding.Default, true);
                    for (string item = reader.ReadLine(); item != null; item = reader.ReadLine())
                    {
                        string[] vektor = item.Split(new string[] { "###" }, StringSplitOptions.RemoveEmptyEntries).Select(x=> x.Trim()).ToArray();
                        vectors.Add(vektor);
                    }
                }
            }
        }
