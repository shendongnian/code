            string re1 = "(\\d+)";	// Integer Number 1
            string re2 = "(\\.)";	// Any Single Character 1
            string re3 = "(\\d+)";	// Integer Number 2
            Regex r = new Regex(re1 + re2 + re3, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                String int1 = m.Groups[1].ToString();
                String c1 = m.Groups[2].ToString();
                String int2 = m.Groups[3].ToString();
                double dblResult = Convert.ToDouble(int1 + c1 + int2);
            }
