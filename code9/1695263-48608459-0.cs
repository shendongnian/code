     class Program
    {
       
        static void Main(string[] args)
        {
            
            Dictionary<int, Article> articles = new Dictionary<int, Article>();
             using (System.IO.StreamReader file = new System.IO.StreamReader(@"\artikli.txt"))
            {
                string line = "";
                int lineCounter = 1;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("|"))
                    {
                        var row = line.Split('|');
                        articles.Add(lineCounter++, new Article() { Code = int.Parse(row[0]), Name = row[1], Amount = row[2] });
                    }
                }
                file.Close();
            }
        }
        public class Article
        {
            public int Code { get; set; }
            public string Name { get; set; }
            public string Amount { get; set; }
            public Article() { }
        }
    }
