    class Program
    {
        static void Main(string[] args)
        {
            string str = "0= 1=Full Time 2=Part Time 3=Seasonal 4=Variable";
            var separated = str.Split('=');
            string code = separated[0].Trim();
            var codeAndDescription = new List<Item>();
            foreach (var sep in separated.Skip(1).Take(separated.Length - 2))
            {
                int lastSpace = sep.Trim().LastIndexOf(' ');
                var description = lastSpace != -1 ? sep.Substring(0, lastSpace).Trim(): "" ;
                codeAndDescription.Add(new Item { Code=code,Description=description });
                code = sep.Substring(lastSpace + 1).Trim();
            }
            codeAndDescription.Add(new Item { Code = code, Description = separated.Last() });
            foreach (var kvp in codeAndDescription)
            {
                Console.WriteLine("Code={0} Description={1}", kvp.Code, kvp.Description);
            }
            Console.ReadLine();
        }
    }
