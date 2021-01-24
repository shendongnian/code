    public class Cow : IAnimal, ITastesGood
    {
        public string MakeSound()
        {
            return "Croak";
        }
    }
    var cow = new Cow();
    var animals = new List<IAnimal>();
    var food = new List<ITastesGood>();
    animals.Add(cow);
    food.Add(cow);
