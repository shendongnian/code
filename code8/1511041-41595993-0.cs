    public interface IGenericManager<T>
    {
        void Add(T obj);
        void Delete(T obj);
        void Update(T obj);
        T View(T obj);
    }
    public class Person
    {
        public string Name { get; set; }
    }
    public class PersonManager : IGenericManager<Person>
    {
        public void Add(Person obj)
        {
            // TODO: Implement
        }
        public void Delete(Person obj)
        {
            // TODO: Implement
        }
        public void Update(Person obj)
        {
            // TODO: Implement
        }
        public Person View(Person obj)
        {
            // TODO: Implement
            return null;
        }
    }
