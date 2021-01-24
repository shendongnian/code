    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public override string ToString()
        {
            return string.Format("Id = {0} & Name = {1} & Salary = {2}", Id, Name, Salary);
        }
    }
