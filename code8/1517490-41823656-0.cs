    string data = "( just some text    (()))just some text  (just some text)    )    ((((just some text) )";
      data = Regex.Replace(data, @"\)", "");
      string[] substrings = Regex.Split(data, @"\(");
      List<string> results = new List<string>();
      string temp = "";
      foreach (string s in substrings) {
        if (s != "") {
          temp = s.Trim();
          results.Add(temp);
        }
      }
      foreach (string s in results) {
        Console.WriteLine(s);
      }
      Console.ReadLine();
