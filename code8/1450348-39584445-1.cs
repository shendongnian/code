    class Cage
    { 
       public int Number { get; set; }
       public List<IAnimal> Animals { get; set;} = new List<IAnimal>();
       public Cage Lockup(IAnimal animal) { Animals.Add(animal); return this;}
    }
