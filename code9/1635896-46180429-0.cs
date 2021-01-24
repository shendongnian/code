    private List<string> ConvertObjectToStringList(Person person)
    {
        List<PropertyInfo> pi = person.GetType().GetProperties(
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).ToList();
        return pi.Select(x => x.GetValue(person).ToString()).ToList();            
    }
