    public bool IsMatch(HashSet<string> segments, string name)
    {
      if (segments.Contains(name))
        return true;
      var q = from s1 in segments
              where name.StartsWith(s1)
              let s2 = name.Substring(s1.Length)
              where s1 != s2
              where segments.Contains(s2)
              select 1; // Dummy. All we care about is if there is one.
      return q.Any();
    }
