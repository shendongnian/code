    public class StarWarsQuery
    {
        public IEnumerable<Droid> Droids()
        {
            return droidRepository.GetAllDroids();
        }
        public Droid Droid(string name)
        {
            return droidRepository.GetDroidByName(name);
        }
    }
    public class Droid
    {
        string name { get; set;}
    }
