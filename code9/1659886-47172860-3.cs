    public static List<ContactTemp> RemoveDupliacacse(
        List<ContactTemp> ContactTempList, 
        IEnumerable<Func<ContactTemp, object>> columnSelectors)
    {
        IEnumerable<ContactTemp> ContactTempListRemobdup = ContactTempList;
        foreach(var selector in columnSelectors)
        {
            ContactTempListRemobdup = ContactTempListRemobdup
                .GroupBy(s => selector(s))
                .Select(group => group.First());
        }
        return ContactTempListRemobdup.ToList();
    }
