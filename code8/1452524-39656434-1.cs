     int count = 50000;
            //string str = File.ReadAllText();
            string fileName = @"C:\Documents\new\example\example.txt";
            List<string> lines = new List<string>();
            using (System.IO.StreamReader file =
                        new System.IO.StreamReader(fileName))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Replace(":1}}", ":" + count + "}}");
                    lines.Add(line);                    
                    count++;
                }
            }
            using (StreamWriter sw = new StreamWriter(fileName,false))
            {
                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }
            }
