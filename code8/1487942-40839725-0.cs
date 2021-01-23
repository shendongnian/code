            char[] dele = { ' ', ',', '.', '\t', ';', '#', '!' };
            using (TextWriter tw = new StreamWriter(@"H:\output.txt"))
            {
                using (StreamReader reader = new StreamReader("H:\\arabictext.txt",Encoding.Default,true))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] stopWord = new string[] { "قد", "في", "بيت", "فواصل", "هي", "من","$","ُ","ِ","ُ","ّ","ٍ","ٌ","ْ","ً" };
                        foreach (string word in stopWord)
                        {
                            line = line.Replace(word, "");
                           
                        }
                        tw.Write(line);
                        
                    }
                }
            }
            FileStream fs = new FileStream(@"H:\\output.txt", FileMode.Open);
            StreamReader arab = new StreamReader(fs,Encoding.Default,true);
            string artx = arab.ReadToEnd();
            arab.Close();
            string[] words = artx.Split(dele);
            FileStream fsw = new FileStream("H:\\result.txt", FileMode.Create);
            StreamWriter arabw = new StreamWriter(fsw,Encoding.Default);
            foreach (string s in words)
            {
               
             arabw.WriteLine(s);
            }
            arabw.Close();
            arab.Close();
        
