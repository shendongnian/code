    string[] names = new string[3]{
         "Tom", "and", "jerry"
    };
    string minValue = names[0];
    foreach (string name in names)
    {
         if (name.Length < minValue.Length)
         {
              minValue = name;
         }
    }
    Console.WriteLine(minValue);
