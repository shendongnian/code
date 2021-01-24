        public class CustomPerson
            {
                public CustomPerson(Person P)
                {
                    FirstName = P.FirstName;
                    LastName = P.LastName;
                }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string FullName
                {
                    get { return string.Format("{0} {1}", FirstName, LastName);}
                }
    
            }
