    foreach (var item in listCommandQuery)
    {
         foreach (var prop in item.GetType().GetProperties())
         {
                  Console.WriteLine(prop.Name);
         }
    }
