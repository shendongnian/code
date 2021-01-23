    public class Customer
    {
        // Or instead of Domain.Customer, it may be a CustomerDto which is used
        // to transfer data from one layer or tier to another.
        // But you get the point.
        public Customer(Domain.Customer customer)
        {
            this.DateOfBirth = customer.DateOfBirth;
            this.Age = customer.Age;
            if (this.DateOfBirth.DayOfYear == DateTime.Today.DayOfYear)
            {
                this.Greeting = "Happy Birthday!!!";
            }
        }
        public int Age { get; set; }
    
        [Required(ErrorMessage = "Date of birth is required.")]
        [Display(Name = "Data of birth")]
        public DateTime DateOfBirth { get; set; }
    
        public string Greeting { get; set; }
    }
