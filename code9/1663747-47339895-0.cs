    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class MainProgram
    {
        public static void Main()
        {
            List<Animal> Animals = new List<Animal>();
            Animals.Add(new Dog());
            Animals.Add(new Poodle());
            Animals.Add(new Poodle());
            Animals.Add(new Beagle());
            Animals.Add(new Cat());
    
            Bark[] JustTheBarks = Dog.GetBarkList(Animals);
            foreach (Bark B in JustTheBarks)
            {
                Console.WriteLine(B.ToString());
            }
        }
    }
    
    abstract class Animal
    {
        public abstract Noise GetNoise();
    }
    
    class Dog : Animal
    {
        public sealed override Noise GetNoise() 
        {
            return GetBark();
        }
    	
    	protected virtual Bark GetBark()
    	{
    		return new Bark("bark");
    	}
    
        public static Bark[] GetBarkList(List<Animal> List)
        {
            return List
                .OfType<Dog>()
                .Select(r => r.GetBark()) //Now calls GetBark() instead of GetNoise()
                .ToArray();
        }
    }
    
    class Beagle : Dog
    {
        protected override Bark GetBark()
        {
            return new Woof("woof", 7);
        }
    }
    
    class Poodle : Dog
    {
        protected override Bark GetBark()
        {
            return new Purr(); //This is now a compiler error.
        }
    }
    
    class Cat : Animal
    {
        public override Noise GetNoise()
        {
            throw new NotImplementedException();
        }
    }
    
    class Noise
    {
    }
    
    class Bark : Noise
    {
        protected string Text;
        public Bark(string Text)
        {
            this.Text = Text;
        }
    
        public override string ToString()
        {
            return $"{Text}";
        }
    }
    
    
    class Woof : Bark
    {
        protected int Pitch;
    
        public Woof(string Text, int Pitch) : base(Text)
        {
            this.Pitch = Pitch;
        }
        public override string ToString()
        {
            return $"{Text}->{Pitch}";
        }
    }
    
    class Purr : Noise { }
