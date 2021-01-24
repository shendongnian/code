     public class PersonFactory //: Factory
        {
            public static T getPerson<T>() where T: IPerson
            {
                return Activator.CreateInstance<T>();
            }
        }
    
    
        public interface IPerson
        {
            string Type { get; }
            int Id { get; set; }        
        }
    
        public class Admin : IPerson
        {
            private string _securityRole;
    
            public Admin()
            {
                Id = 0;
            }
    
            public string Type
            {
                get
                {
                    return "admin";
                }
            }
    
            public string SecurityRole
            {
                get { return _securityRole; }
                set { _securityRole = value; }
            }
    
            public int Id
            {
                get;set;
            }
        }
    
        public class Customer : IPerson
        {
            private string _securityRole;
    
            public Customer()
            {
                Id = 0;
            }
    
            public string Type
            {
                get
                {
                    return "customer";
                }
            }
    
            public string SecurityRole
            {
                get { return _securityRole; }
                set { _securityRole = value; }
            }
    
            public int Id
            {
                get;set;
            }
        }
