    public class Customer
    {
        public Customer(IRegistrar registrar)
        {
            this.registrar = registrar;
        }
        public int Age
        {
            get
            {
                // Just for this example. This will not work for all locals etc but beyond the point here.
                var today = DateTime.Today;
                return today.Year - this.DateOfBirth.Year;
            }
        }
    
        public DateTime DateOfBirth { get; set; }
           
        public int Register()
        {
            if (this.Age < 18)
            {
                throw new InvalidOperationException("You must be at least 18 years old");
            }
            int id = this.registrar.Register(this);
            return id;
        }
    }
    public interface IRegistrar 
    {
        public int Register(Customer customer);
    }
