    portTextBox.Text = Config_check(item, "Port", 1);
    private string Config_check(string item, string contains, int i)
    {
        string part = "defualt";
        if (item.Contains(contains))
        {
            MatchCollection Parts = Regex.Matches(item, @"(?i); *(.+?);(?-i)", RegexOptions.Singleline);
            foreach (Match m in Parts)
            {
                part = m.Groups[i].Value;
                MessageBox.Show(part);
            }
            MessageBox.Show(part);
        }
        MessageBox.Show(part);
        return part;
    }
