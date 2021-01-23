    public abstract class Animal
    {
        public static string GENUSSPECIES;
        public abstract string GenusSpecies { get; }
        public string Name;
        public Animal(string name)
        {
            Name = name;
        }
    }
