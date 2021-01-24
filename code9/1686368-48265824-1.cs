    using System.Text.RegularExpressions;
    ...
    string text = "Elijah Jordan Wood is an ...";
    string border = "\"erd3\"";
    int index = text.IndexOf(border);
    string result = index < 0
      ? text // "\"erd3\"" has not been found, nothing to change
      : text.Substring(0, index + border.Length) +             // prefix (intact)
          Regex.Replace(text.Substring(index + border.Length), // subtraction: 
                        "\"erd(?<item>[0-9]+)\"",              //   pattern to find
                        m => "\"erd" +                         //   "erd" + item - 1 + "
                             (int.Parse(m.Groups["item"].Value) - 1).ToString() + 
                             "\"");
