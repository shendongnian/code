    public override int GetHashCode(string obj)
    {
      if (obj == null) return 0;
      if (_re.IsMatch(obj)) return 1;
      return obj.GetHashCode(); // catch the reference-equals part for non-matches.
    }
