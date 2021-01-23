    public bool ContainsCI(string input, string term)
    {
      if (String.IsNullOrWhitespace(input))
      {
           return false;
      }
      //Returns true even if `terms` is empty, just like String.Contains
      return input.IndexOf(term,StringComparison.CurrentCultureIgnoreCase)!= -1);
    }
    ...
    
    var term=txtSearchbar.Text;
    var results= People.Where(a => ContainsCI(a.Namn, term)
                                || ContainsCI(a.PostOrt,term));
    ListBoxOne.Items.AddRange(results);
