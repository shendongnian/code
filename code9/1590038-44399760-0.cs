    using System;
    public abstract class Human
    {
        public string Name;
        public abstract string GetDetails();
    }
    public class Woman : Human
    {
        public bool IsPregnant;
        public override string GetDetails() 
        {
            return Name + " is " + (IsPregnant ? "pregnant." : "not pregnant.");
        }
    }
    public class Man : Human
    {
        public int NumberOfComputers;
        public override string GetDetails() 
        {
            return Name + " has " + NumberOfComputers + " computers.";
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var andrew = new Man 
            {
                Name = "Andrew",
                NumberOfComputers = 200
            };
            OutputDetails(andrew);
        }
        public static void OutputDetails(Human myHuman)
        {
            Console.WriteLine(myHuman.GetDetails());
        }
    }
