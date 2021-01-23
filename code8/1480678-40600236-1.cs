        public class AgeComparer: Comparer<Person> 
        {
            public override int Compare(Person x, Person y)
            {   
            
               return x.Age.CompareTo(y.Age);      
            }    
        }
        public class LastNameThenAgeComparer: Comparer<Person> 
        {
            public override int Compare(Person x, Person y)
            {       
                if (x.LastName.CompareTo(y.LastName) != 0)
                {
                   return x.LastName.CompareTo(y.LastName);
                }
                else (x.Age.CompareTo(y.Age) != 0)
                {
                   return x.Age.CompareTo(y.Age);
                }    
            }    
        }
    //// other types of comparers
