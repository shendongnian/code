    using System.Text.RegularExpressions;
    ...
    string text = "Elijah Jordan Wood is an ...";
    string border = "\"erd3\"";
    int index = text.IndexOf(border);
    string result = index < 0
      ? text
      : text.Substring(0, index + border.Length) +
          Regex.Replace(text.Substring(index + border.Length),
                        "\"erd(?<item>[0-9]+)\"",
                        m => "\"erd" + 
                             (int.Parse(m.Groups["item"].Value) - 1).ToString() + 
                             "\"");
