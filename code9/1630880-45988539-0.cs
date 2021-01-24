    class Program
        {
            static void Main(string[] args)
            {
    
                var list = new List<string>();
                list.Add("1111");
                list.Add("1111.0");
                list.Add("1111.10");
                foreach (string num in list)
                {
                   
                    Regex re = new Regex("([0-9]+)(?:\\.)?(\\d)?(\\d)?");
                    Match match = re.Match(num);
                   
                    Console.WriteLine();
                    if (match.Success)
                    {
                        Console.WriteLine(match.Groups[1].Value + "." + match.Groups[2].Value.PadRight(1,'0') + match.Groups[3].Value.PadRight(1, '0'));
                    }
                }
                Console.Read();
    
            }
        }
