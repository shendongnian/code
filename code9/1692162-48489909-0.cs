    var categories = new List<Category>(); // Create a categories list.
    while (true) { // Loop as long as the user enters some category name.
        Console.WriteLine("Enter name of category: ");
        string s = Console.ReadLine(); // Read user entry.
        if (String.IsNullOrWhiteSpace(s)) {
            // No more entries - exit loop
            break;
        }
        // Create a new category and assign it the entered name.
        var category = new Category { name = s };
        // Add the category to the list.
        categories.Add(category);
    }
    File.WriteAllLines(yourFilePath, categories);
    
