    class LivingRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Person> Persons { get; set; }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LivingRoom LivingRoom { get; set; }
        public int LivingRoomId { get; set; }
    }
