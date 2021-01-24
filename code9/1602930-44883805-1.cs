     string str = "Today is a nice day, and I have been driving a car";
     Regex r = new Regex("[a-zA-Z]+", RegexOptions.IgnoreCase);
     MatchCollection m = r.Matches(str);
     List<string> list = new List<string>();
    
     var howManyToRemove= m.Count % 3;
     if (howManyToRemove!= 0)
     {
       m.RemoveAt(m.Count - howManyToRemove- 1);
     }
    
     for (var i = 0; i < m.Count; i++)
     {
     list.Add(string.Format("{0} {1} {2}", m[i], m[i + 1], m[i + 2]));
     i = i + 2;
     }
