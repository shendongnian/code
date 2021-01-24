            string txt = System.IO.File.ReadAllText("myfile.txt");
            List<string> lines = txt.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string line in lines)
            {
                string name = System.Text.RegularExpressions.Regex.Replace(line, @"[\d-]", string.Empty).Trim();
            }
