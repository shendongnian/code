            var codes = new List<string>();
            var games = new List<string>();
            foreach(var s in richTextBox1.Lines)
            {
                string[] p = s.Split(new char[] { ' ' }, 2);
                if (p.Count() == 1) { continue; }
                codes.Add(p[0]);
                games.Add(p[1]);
            }
