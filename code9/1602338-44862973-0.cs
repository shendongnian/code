            string[] Paths = Directory.GetFiles(path, "*.txt");
            string[] stripchars1 = { "<", "?", ".","\"" };
            string[] chars2 = { "s", "w", "n" };
            foreach (string file in Paths)
            {
                using (StreamReader objstream = new StreamReader(file))
                {
                    using (StreamWriter objstream2 = new StreamWriter(file + ".new"))
                    {
                        string s = objstream.ReadToEnd();
                        foreach (string character in stripchars1)
                        {
                            s = s.Replace(character, " ");
                        }
                        foreach (string character in chars2)
                        {
                            s = s.Replace(character, "h");
                        }
                        objstream2.Write(s);
                    }
                }
            }
