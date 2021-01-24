    using Dapper.Contrib.Extensions;
    public class Customer
    {
        [Key]
        public int Recid { get; set; }
        public string Name { get; set; }
    
        public Customer()
        {
    
        }
    }
