    public interface IPerson {
        int ID { get; set; }
        string Name { get; set; }
        string Address { get; set; }
    }
    public class Person : IPerson {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class PersonModel : IPerson {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public static List<T> BuildList<T>() where T : IPerson, new() {
        var result = new List<T>();
        for (int i = 0; i < 10; i++) {
            result.Add(new T() {
                ID = i,
                Address = "address" + i
            });
        }
        return result;
    }
