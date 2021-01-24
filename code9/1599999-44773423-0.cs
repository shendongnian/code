    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;  }
        public string Address { get; set; }
        public string PersonToCSVLine
        {
            get
            {
                //Places commas between fields, string quotes around address
                return String.Concat(this.Id.ToString(), "," , this.FirstName, "," , this.LastName, ",\"", this.Address, "\"" );
            }
        }
    }
