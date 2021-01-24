    using (StreamWriter tw = new StreamWriter(@"file1.txt"))
            {
                using (System.IO.TextReader tr = File.OpenText((@"file.txt")))
                {
                    string line;
                    StringBuilder items = new StringBuilder();
                    while ((line = tr.ReadLine()) != null)
                    {
                        items.Append(line);
                        items.Replace("a ", "a");
                        items.Replace("b ", "b");
                        tw.WriteLine(items);
                        items.Clear();
                    }
                }
            }
