    // create a list to hold animals in 
    var allAnimals = new List<Animal>();    
        
    while (another == "y")
    {
        Console.WriteLine("Type in the animal's species: ");
        species = Console.ReadLine();
        Console.WriteLine("Type in the animal's age: ");
        age = Console.ReadLine();
        
        // create the animal..
        var newAnimal = new Animal(species, age);
        // ..and add it in the list.
        allAnimals.Add(newAnimal);
        Console.WriteLine("Type y to create another animal or n to end: ");       
        another = Console.ReadLine();
    }
