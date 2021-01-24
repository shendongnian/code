            string re1 = ".*?";
            string re2 = "USSS\",([0-9]+\\.[0-9]+),([0-9]+\\.[0-9]+)";
            Regex g = new Regex(re1 + re2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            
            using (StreamReader r = new StreamReader("airports.dat"))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    Match m = g.Match(line);
                    if (m.Success)
                    {
                        string v1 = m.Groups[1].Value;
                        string v2 = m.Groups[2].Value;
                        MessageBox.Show(v1);
                        MessageBox.Show(v2);
                    }
                }
            }
