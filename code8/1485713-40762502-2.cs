      static void Main(string[] args)
      {
          Console.WriteLine("Enter animal type, please");
          String animalType = Console.ReadLine();
          Func<IAnimal> maker; 
          if (s_Factory.TryGetValue(animalType, out maker)) 
            maker().Bark();
          else
            Console.WriteLine("Sorry, I don't know such an animal"); 
      }
