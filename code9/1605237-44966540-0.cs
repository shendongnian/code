            public abstract class Entity
            {
                public int Id { get; set; }
            }
    
            public class City : Entity
            {
                public string CityName { get; set; }
            }
    
            public class Person : Entity
            {
                public string PersonName { get; set; }
            }
    
            public class MethodHost
            {
                public void Insert(Entity e)
                {
                    if (e is Person person)
                    {
                        // Do something with person
                    } else if (e is City cityName)
                    {
                        // Do something with city
                    }
                }
            }
