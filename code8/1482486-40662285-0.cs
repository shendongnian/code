    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Person, PersonViewModel>()
                    .ForMember(p => p.Name, c =>
                    {
                        c.Condition(new Func<Person, bool>(person =>
                        {
                            Console.WriteLine("Condition");
                            return true;
                        }));
                        c.PreCondition(new Func<Person, bool>(person =>
                        {
                            Console.WriteLine("PreCondition");
                            return true;
                        }));
                        c.MapFrom(p => p.Name);
                    });
            });
            Mapper.Instance.Map<PersonViewModel>(new Person() { Name = "Alberto" });
        }
    }
    class Person
    {
        public long Id { get; set; }
        private string _name;
        public string Name
        {
            get
            {
                Console.WriteLine("Getting value");
                return _name;
            }
            set { _name = value; }
        }
    }
    class PersonViewModel
    {
        public string Name { get; set; }
    }
