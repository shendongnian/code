    public class Cat : Animal
    {
        public static new string GENUSSPECIES = "Felis Catus"; 
        public Cat(string name) : base(name) { }
        public override string GenusSpecies
        {
            get { return Cat.GENUSSPECIES; }
        }
    }
