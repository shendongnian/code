    // Group the pets using Age as the key value 
    // and selecting only the pet's Name for each value.
    IEnumerable<IGrouping<int, string>> query =
        pets.GroupBy(pet => pet.Age, pet => pet.Name);
    // Iterate over each IGrouping in the collection.
    foreach (IGrouping<int, string> petGroup in query)
    {
        // Print the key value of the IGrouping.
        Console.WriteLine(petGroup.Key);
        // Iterate over each value in the 
        // IGrouping and print the value.
        foreach (string name in petGroup)
            Console.WriteLine("  {0}", name);
    }
