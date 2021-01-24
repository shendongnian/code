    using System.Text.RegularExpressions;
    var match = Regex.Match("MD00123", @"^([^0-9]+)([0-9]+)$");
    var num = int.Parse(match.Groups[2].Value);   
    var after = match.Groups[1].Value + (num + 1).ToString("D4");
    MessageBox.Show(after.ToString());
