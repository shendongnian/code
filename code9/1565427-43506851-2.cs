     string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string filename = Path.Combine(path, "file.txt");
                using (var streamWriter = new StreamWriter(filename, true))
                {
                    streamWriter.WriteLine("{\"Keep_Active\":1,\"Speech_Words\":0}");
                }
