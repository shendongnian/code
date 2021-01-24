    public IEnumerable<string> Method(string s)
    {
        if(s == null)
           throw new ArgumentNullException(nameof(s));
 
        return MethodIterator(s);
    }
    private IEnumerable<string> MethodIterator(string s)
    {
        if(dictionary.TryGetValue(s, out list))
        {
            foreach(string k in list)
               yield return k;
        }
    }
