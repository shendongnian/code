    foreach (var item in transactionList)
    {
         foreach (var property in item.GetType().GetProperties())
         {
             Console.WriteLine("{0}={1}", property.Name, property.GetValue(item, null));
         }                
    }
    Console.ReadLine();
