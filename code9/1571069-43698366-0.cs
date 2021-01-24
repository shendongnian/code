    Regex g = new Regex(@"\""USSS\"",(\d+\.\d{12}),(\d+\.\d{12})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            using (StreamReader r = new StreamReader("airports.dat"))
            {                
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    Match m = g.Match(line);
                    if (m.Success)
                    {
                        
                        string v = m.Groups[1].Value;
                        string v2 = m.Groups[2].Value;
                        MessageBox.Show(v);
                        MessageBox.Show(v2);
                    }
                    // Do stuff with line.
                }
            }
