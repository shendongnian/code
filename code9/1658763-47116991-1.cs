        class PersonComparer : Comparer<Person>
        {
            public override int Compare(Person x, Person y)
            {
                // 2 Persons are the same if givenName and lastName are the same.
                if (x.givenName == y.givenName && x.lastName == y.lastName)
                {
                    return 0;
                }
                return 1;
            }
        }
