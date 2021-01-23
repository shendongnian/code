    foreach (string[] item in loggbok)
    {
       foreach (string s in item)
       {
          //This was the magic line.
          string searchTitle = item[1].ToLower();
          if (searchTitle.Contains(titleKey.ToLower()))
          {
             Console.WriteLine("\n\tSearch hit #" + index);
             foundItem = true;
             Console.WriteLine(String.Join("\r\n", item));
             index++;
  
             break;
          }
       }
    }
