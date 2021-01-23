            var input = new List<string>();
            input.Add("(c");
            input.Add("*b");
            input.Add("_a");
            Regex reg = new Regex(@"[^a-zA-Z]");
            var result = input.OrderBy(x => reg.Replace(x, string.Empty)).ToArray();
