	class Program
    {
        static void Main(string[] args)
        {
            var persons = Setup();
            //option 1, can stream, option suggested by Jon Skeet
            //http://stackoverflow.com/a/1300116/897326
            var result1 = persons.
                DistinctBy(m => new {m.FirstName, m.LastName});
            //option 2, cannot stream, but does reference to DistinctBy
            //http://stackoverflow.com/a/4158364/897326
            var result2 = persons.
                GroupBy(m => new { m.FirstName, m.LastName }).
                Select(group => group.First());
        }
        
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
        }
        private static List<Person> Setup()
        {
            var p1 = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Address = "USA"
            };
            var p2 = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Address = "Canada"
            };
            var p3 = new Person
            {
                FirstName = "Jane",
                LastName = "Doe",
                Address = "Australia"
            };
            var persons = new List<Person>();
            persons.Add(p1);
            persons.Add(p2);
            persons.Add(p3);
            return persons;
        }
    }
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
