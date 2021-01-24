    class Program
    {
        static string Preprocess(string s)
        {
            bool esc = false, quoted = false;
            StringBuilder sb = new StringBuilder();
            foreach (var c in s)
            {
                if (c == '\\' && !esc)
                    esc = true;
                else
                {
                    if (c == '\"' && !esc)
                        quoted = !quoted;
                    else
                    {
                        if (c == '=' && quoted)
                            sb.Append('~');
                        else if (c == ',' && quoted)
                            sb.Append(';');
                        else
                            sb.Append(c);
                    }
                    esc = false;
                }
            }
            return sb.ToString();
        }
        static string Postprocess(string s)
        {
            return s.Replace('~', '=').Replace(';', ',');
        }
        static Dictionary<string, string> MakeKeyValueList(string str)
        {
            var dict = new Dictionary<string, string>();
            foreach (var kvp in Preprocess(str).Split(','))
            {
                string[] kv = kvp.Split(new char[] { '=' }, 2);
                if (kv.Length == 2)
                    dict[Postprocess(kv[0]).Trim()] = Postprocess(kv[1]).Trim();
            }
            return dict;
        }
        static void Main(string[] args)
        {
            var dict = MakeKeyValueList("name=\"Dave O'Connel\", \"e-mail\"=\"dave@mailinator.com\", epoch=1498158305, \"other value\"=\"some arbitrary\\\" text, with comma = and equals symbol\"");
            foreach (var kvp in dict)
                Console.WriteLine(kvp.ToString());
            Console.ReadKey();
        }
    }
