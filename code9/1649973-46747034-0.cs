    public class Dog : TemplateMammals
    {
        public void SomethingWhereINeedStuff()
        {
            var stuff = GetAnimalStuff();
            // stuff is of type MammalsStuff
        }
    }
    
    public class TempalteMammals : TemplateAnimals<MammalsStuff>
    {
        public abstract MammalsStuff GetAnimalStuff() { ... }
    }
    
    public class TemplateAnimals<TStuff> where TStuff : AnimalStuff 
    {
        public abstract TStuff GetAnimalStuff();
    }
