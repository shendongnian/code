     public class Model
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public string Sports { get; set; }
            public List<Model> Models
            {
                get
                {
                    return objModels;
                }
    
                set {
                    Model = value;
                }
    
            }
    
            List<Model> objModels = new List<Model>() {
                new Model { Name = "Manish", Age = 27, Sports = "Cricket" },
                new Model { Name = "Rajan", Age = 25, Sports = "FootBall" },
                new Model { Name = "Prashant", Age = 25, Sports = "Kabaddi" },
                new Model { Name = "Garima", Age = 24, Sports = "Ludo" },
                new Model { Name = "Neha", Age = 25, Sports = "Carom" }
            };
        }
