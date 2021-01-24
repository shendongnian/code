    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace MultipleClasses
    {
       class Animal
       {
          public int hands { get; set; }
          public Boolean feathers { get; set; }
          public int legs { get; set; }
          public Animal(int l = 0, int h = 0, Boolean f = false)
          {
            this.legs = l;
            this.hands = h;
            this.feathers = f;
          }
      }
    
      class Dog : Animal
      {
         public string name { get; set; }
         public int age { get; set; }
         public Dog(string n, int g, int l, int h, Boolean f)
         {
            this.name = n;
            this.age = g;
            this.legs = l;
            this.hands = h;
            this.feathers = f;
          }
      }
      
      class Program
      {
        static void Main(string[] args)
        {
            Dog a = new Dog("Jack", 5, 4, 0, false);
            Console.WriteLine("The Dog's name is {0} and age is {1}", a.name.ToString(), a.age.ToString());
        }
      }
    }
