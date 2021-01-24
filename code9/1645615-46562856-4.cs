          public class Person
           {
            
            private string firstName;
            private string lastName;
    
            public Person(string firstName, string lastName)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
            }
    
            public string FirstName
            {
                get
                {
                    return this.firstName;
                }
                set
                {
                    if (value == null)
                    {
                        throw new NullReferenceException("The first name must not be null!");
                    }
    
                    this.firstName = value;
                }
            }
    
            public string LastName
            {
                get
                {
                    return this.lastName;
                }
                set
                {
                    if (value == null)
                    {
                        throw new NullReferenceException("The last name must not be null!");
                    }
    
                    this.lastName = value;
                }
            }
