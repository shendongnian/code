       public class Program
        {
            static void Main(string[] args)
            {
                Regex regex = new Regex("^(?:(?:[, ]+)?(?\'q\'\")?(?\'key\'[^=\"]*?)(?:\\k\'q\'(?\'-q\'))?=(?\'q\'\")?(?\'value\'(?:[^\"]|(?<=\\\\)\")*)(?:\\k\'q\'(?\'-q\'))?)*(?(q)(?!))$", RegexOptions.Compiled);
    
                string s = "name=\"Dave O\'Connel\", \"e-mail\"=\"dave@mailinator.com\", epoch=1498158305, \"other value\"=\"some arbitrary\\\" text, with comma = and equals symbol\"";
    
                Match match = regex.Match(s);
    
                if (match.Success)
                {
                    var keys = match.Groups["key"].Captures;
                    var values = match.Groups["value"].Captures;
    
                    for (int i = 0; i < keys.Count; i++)
                    {
                        Console.WriteLine(keys[i] + " = " + values[i]);
                        // this prints:
                        // name = Dave O'Connel
                        // e-mail = dave@mailinator.com
                        // epoch = 1498158305,
                        // other value = some arbitrary\" text, with comma = and equals symbol
                    }
                }
    
                Console.ReadLine();
            }
        }
