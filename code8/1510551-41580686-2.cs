    Pizza requestedPizza;
    foreach (Pizza pizza in allPizzas)
    {
         if (pizza.Price == enteredPrice)
         {
             requestedPizza = pizza;
             break;
         }
    }
    Console.WriteLine($"Found pizza size {requestedPizza.Size} that matches price {requestedPizza.Price}");
