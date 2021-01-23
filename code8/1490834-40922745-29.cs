    //this parses out the string input, does not use the classifications
    List<string> members = new List<string>();
    string input = "Customers: David, Danny, Mike, Luke. Car: BMW";
    string[] t1 = input.Split(new string[] {". "},         StringSplitOptions.RemoveEmptyEntries);
    foreach (String t in t1)
    {
      string[] t2 = t.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
      string[] t3 = t2[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
      foreach (String s in t3)
      {
        members.Add(s.Trim());
      }
    }
