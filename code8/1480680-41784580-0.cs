    //sort a person object by age first, then by last name
        class Person : IComparable<Person>, IComparable
        {
            public string LastName { get; }
            public string FirstName { get; }
            public int Age { get; }
    
            public Person(string vorname, string nachname, int age)
            {
                LastName = vorname;
                FirstName = nachname;
                Age = age;
            }
    
            // used by the default comparer
            public int CompareTo(Person p)
            {
                // make sure comparable being consistent with equality; this will use IEquatable<Person> if implemented on Person hence better than static Equals from object
                if (EqualityComparer<Person>.Default.Equals(this, p)) return 0;
    
                if (p == null)
                    throw new ArgumentNullException(nameof(p), "Cannot compare person with null");
                if (Age.CompareTo(p.Age) == 0)
                {
                    return LastName.CompareTo(p.LastName);
                }
                return Age.CompareTo(p.Age);
            }
    
            // explicit implementation for backward compatiability 
            int IComparable.CompareTo(object obj)
            {
                Person p = obj as Person;
                return CompareTo(p);
            }
    
            public override string ToString() => $"{LastName} {FirstName} \t {Age}";
        }
