    // Path to our inventory file
    var filePath = @"f:\public\temp\inventory.txt";
    if (File.Exists(filePath))
    {
        var fileContents = File.ReadAllLines(filePath);
        foreach (var inventoryLine in fileContents)
        {
            // Ensure our line has some content
            if (string.IsNullOrWhiteSpace(inventoryLine)) continue;
                    
            // Split the line on the comma character
            var inventoryLineParts = inventoryLine.Split(',');
            var inventoryItem = new InventoryItem();
            // These will hold the values of Cost and Quantity if `double.TryParse` succeeds
            double cost;
            double qty;
            // Assign each part of the line to a property of the InventoryItem
            inventoryItem.CategoryName = inventoryLineParts[0];
            if (inventoryLineParts.Length > 1)
            {
                inventoryItem.FoodName = inventoryLineParts[1];
            }
            if (inventoryLineParts.Length > 2 && 
                double.TryParse(inventoryLineParts[2], out cost))
            {
                inventoryItem.Cost = cost;
            }
            if (inventoryLineParts.Length > 3 && 
                double.TryParse(inventoryLineParts[3], out qty))
            {
                inventoryItem.Quantity = qty;
            }
            // Add this InventoryItem to our ListBox
            wnd.ListBox.Items.Add(inventoryItem);
        }
    }
