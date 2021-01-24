    class Program
    {
        static void Main(string[] args)
        {
            string s = "[5111110233857£254736283045£1000£25£212541£20120605152412 £KEN£NAI],[5111110233858£254736283045£2500£25£257812£2012 0605152613£KEN£NAI]";
            s = s.Replace("[", "").Replace("]", "");
            var split_s = s.Split(',');
            List<string> ans = new List<string>();
            foreach(var x in split_s)
            {
                var t = x.Split('£');
                foreach(var y in t)
                {
                    ans.Add(y);
                }
            }
            foreach(var x in ans)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
