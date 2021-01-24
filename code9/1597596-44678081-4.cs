    public enum TypeOfContact
    {
        Unknown,
        Email
    }
    public class Person
    {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public TypeOfContact ContactType { get; set; }
        public string ContactValue { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            // test data to simulate a database table
            var Persons = new List<Person>
            {
                // + All conditions met
                new Person { Name = "john doe", Birth = new DateTime(2011, 1, 1), ContactType = TypeOfContact.Email, ContactValue = "john.doe@email.com" },
                // - Not in result
                new Person { Name = "danny doe", Birth = new DateTime(2012, 1, 1), ContactType = TypeOfContact.Email, ContactValue = "johndoe@hotmail.com" },
                // + Name contains john
                new Person { Name = "john doe", Birth = new DateTime(2013, 1, 1), ContactType = TypeOfContact.Unknown, ContactValue = "" },
                // + Birth, ContactType and ContactValue correct
                new Person { Name = "justin", Birth = new DateTime(2014, 1, 1), ContactType = TypeOfContact.Email, ContactValue = "slenderman@email.com" },
                // - Not in result because Name and Birth are wrong
                new Person { Name = "jonny", Birth = new DateTime(1979, 1, 1), ContactType = TypeOfContact.Email, ContactValue = "you-know-who@email.com" },
                // - Not in result
                new Person { Name = "jenny doe", Birth = new DateTime(2016, 1, 1), ContactType = TypeOfContact.Unknown, ContactValue = "" },
            }.AsQueryable();
            // single-line-conditions
            Expression<Func<Person, bool>> c1 = p => p.Name.Contains("john");
            Expression<Func<Person, bool>> c2 = p => p.Birth.Date >= new DateTime(1980, 1, 1);
            Expression<Func<Person, bool>> c3 = p => p.ContactType == TypeOfContact.Email;
            Expression<Func<Person, bool>> c4 = p => p.ContactValue.EndsWith("@email.com");
            // DNF groups: outer list = or; inner list = and
            // c1 or (c2 and c3 and c4)
            var conditionList = new List<List<Expression<Func<Person, bool>>>>
            {
                new List<Expression<Func<Person, bool>>>
                {
                    c1,
                },
                new List<Expression<Func<Person, bool>>>
                {
                    c2,
                    c3,
                    c4,
                },
            };
            var andSubResults = new List<IQueryable<Person>>();
            foreach (var andQueries in conditionList)
            {
                var subQuery = Persons;
                foreach (var andQuery in andQueries)
                {
                    subQuery = subQuery.Where(andQuery);
                }
                andSubResults.Add(subQuery);
            }
            var query = andSubResults.FirstOrDefault();
            foreach (var subResult in andSubResults.Skip(1))
            {
                query = query.Union(subResult);
            }
            var selection = query.ToList();
            // just check the result in debugger
        }
    }
