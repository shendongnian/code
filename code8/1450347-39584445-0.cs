    class Cage
    { 
       public int Number { get; set; }
       public List<IAnimal> Animals { get; set;}
       public void Lockup(IAnimal animal) { Animals.Add(animal); }
    }
