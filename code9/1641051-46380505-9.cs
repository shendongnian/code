    var duplicates = result.AsEnumerable()
                .GroupBy(x => x, new PersonyComparer() )
                .Where(g => g.Count() > 1)
    class PersonyComparer : IEqualityComparer<Person>//person is the type of objects that are in starting collection
        {
            public bool Equals(Person b1, Person b2)
            {
                if (b2 == null && b1 == null)
                    return true;
                else if (b1 == null | b2 == null)
                    return false;
                
    
                if(/*your condition*/)
                    return true;
                else
                    return false;
            }
    
            public int GetHashCode(Person bx)
            {
                return 0; //you must make sure that objects that are equal have same hashcode
            }
        }
