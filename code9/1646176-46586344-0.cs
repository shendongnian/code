    class Dish {
        string Name { get; set; }
        //Additional properties and/or methods would go here
    }
    
    //...
    
    Dictionary<int, Dish> dishes = new Dictionary<int, Dish> {
        { 1, new Dish { Name = "Pasta Bolognese" } },
        { 2, new Dish { Name = "Pizza Napolitana" } },
        { 35, new Dish { Name = "Pizza Funghi" } },
        { 36, new Dish { Name = "Pizza Carbonara" } }
    }
    
    int id = Convert.ToInt32(Console.ReadLine());
    
    //...
    
    bool hasDish = dishes.TryGet( id, out Dish selectedDish);
     
    if (hasDish)
    {
        Console.WriteLine($"{selectedDish.Name} is added to your list.");
        //You can extend your Dish class with further properties and methods and use them here
    }
    else
    {
        Console.WriteLine($"{id} is not available.");
    }
