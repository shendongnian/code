    public List<ContactTemp> RemoveDupliacacse(List<ContactTemp> ContactTempList, 
         List<string> objcolumn)
    {            
        var type = typeof(ContactTemp);
        foreach (var column in objcolumn)
        {
            var property = type.GetProperty(column);
            ContactTempList = ContactTempList.GroupBy(x => property.GetValue(x))
                                             .Select(x => x.First()).ToList();
        }
        return ContactTempList;
    }
