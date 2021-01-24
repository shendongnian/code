    namespace Ex6.Entities
    {
        public class Car
        {
            public int Id { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
    
            public Car(int _Id, string _Make, string _Model)
            {
                Id = _Id;
                Make = _Make;
                Model = _Model;
            }
        }
    }
