      static void Main(string[] args)
        {
            string line;
            List<string> classLst = new List<string>();
            List<string> methodLst = new List<string>();
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\******\Desktop\TreeView.txt");
            string str = File.ReadAllText(@"C:\Users\*******\Desktop\TreeView.txt");
            while ((line = file.ReadLine()) != null)
            {      
                    if (line.Contains("class")&&!line.Contains("///"))
                    {
                        // for finding class names
                        int si = line.IndexOf("class");
                        string followstring = line.Substring(si);
                        if (!string.IsNullOrEmpty(followstring))
                        {
                            string[] spilts = followstring.Split(' ');
                            if(spilts.Length>1)
                            {
                                classLst.Add(spilts[1].ToString());
                            }
                        }
                    }
            }
            MatchCollection mc = Regex.Matches(str, @"(\s)([A-Z]+[a-z]+[A-Z]*)+\(");
            foreach (Match m in mc)
            {
                methodLst.Add(m.ToString().Substring(1, m.ToString().Length - 2));
                //Console.WriteLine(m.ToString().Substring(1, m.ToString().Length - 2));
            }
            file.Close();
            Console.WriteLine("******** classes ***********");
            foreach (var item in classLst)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("******** end of classes ***********");
            Console.WriteLine("******** methods ***********");
            foreach (var item in methodLst)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("******** end of methods ***********");
            Console.ReadKey();
        }
