    class Car : IVehicle
    {
        public int Id { get; set; }
        private string _name;
    
        public string Name { get { return _name; } set { _name = value; } }
        public void Print()
        {
            Console.WriteLine($"Id {Id} Name {Name}");
        }
    }
