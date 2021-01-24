            string filepath = "myfile.txt";
            int lineCount = 0;
            List<string> list = new List<string>();
            using (StreamReader sr = File.OpenText(filepath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lineCount++;
                    if (lineCount % 100 == 0 || sr.Peek().Equals(-1))
                    { 
                        SaveToDB(list);
                        list = new List<string>();
                    }
                }
            }
