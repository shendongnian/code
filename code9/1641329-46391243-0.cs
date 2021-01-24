    string[] INGREDIENTS = {"Salt", "Sugar"};
    foreach (string line in myList)
    {
        foreach (string ingredient in INGREDIENTS)
        {   
            if (line.Contains(ingredient))
            {
                MessageBox.Show($"The ingredient found in this line of myList is: {ingredient}");
            }
        }
    }
