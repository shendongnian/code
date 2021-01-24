     var list = new int[] { 4,5,6};
    
     var whereFunction = new Interpreter()
    .SetVariable("mylist", list)
    .Reference(typeof(ExtensionMethods));
    
     whereFunction.ParseAsExpression<Func<Person, bool>>("(person.Age == 5 && person.Name.StartsWith(\"G\")) || person.Age == 3 && mylist.Exists(person.Id)", "person");
    // Define this class somewhere
    public static class ExtensionMethods
    {
        public static bool Exists<T>(this IEnumerable arr, T searchKey)
        {
            return ((IEnumerable<T>)arr).Contains(searchKey);
        }
    }
