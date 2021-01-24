            Regex regex1 = new Regex("(([-a-zA-Z0-9])|([-a-zA-Z0-9]{1,256}[@%._\+~#=][-a-zA-Z0-9])){1,10}\.[-a-zA-Z0-9]{1,10}\b",RegexOptions.IgnoreCase)
            string[] domains = richTextBox_domains.Text.Split(';');
        List<string> l = new List<string>();
            for (int x = 0; x < domains.Length; x++)
                                    {
            var results = regex1.Matches(domains[x]);
            foreach (Match match in results)
            {
              l.Add(match.Groups[1].Value);
      MessageBox.Show(match.Groups[1].Value);
            }
        }
    
     string[] s = l.ToArray();// new array
