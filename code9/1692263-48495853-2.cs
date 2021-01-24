    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    
    class Template
    {
        public string Expand(params string[] dynamics)
        {
            string[][] tables = new string[][] { statics, dynamics };
            StringBuilder sb = new StringBuilder();
            foreach (var index in indices)
            {
                sb.Append(tables[index.Item1][index.Item2]);
            }
            return sb.ToString();
        }
    
        private Tuple<int, int>[] indices;
        private string[] statics;
    
        public Template(string source)
        {
            int last = 0;
            List<string> statics = new List<string>();
            List<Tuple<int, int>> indices = new List<Tuple<int, int>>();
            foreach (Match match in Regex.Matches(source, @"\{(\d+)\}"))
            {
                if (match.Index > last)
                {
                    // emit a static portion
                    indices.Add(Tuple.Create(0, statics.Count));
                    statics.Add(source.Substring(last, match.Index - last));
                }
                // emit the dynamic portion
                indices.Add(Tuple.Create(1, int.Parse(match.Groups[1].Value)));
                last = match.Index + match.Length;
            }
            // emit any leftovers
            if (last < source.Length)
            {
                indices.Add(Tuple.Create(0, statics.Count));
                statics.Add(source.Substring(last));
            }
            this.statics = statics.ToArray();
            this.indices = indices.ToArray();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Template t = new Template("Hello, {0}. You are {1}! Thanks, {0}.");
    
            Console.WriteLine(t.Expand("Adam", "a man"));
            Console.WriteLine(t.Expand("Eve", "a woman"));
            Console.WriteLine(t.Expand("jhilgeman", "cool"));
        }
    }
