    string[] ingredients = { "Salt", "Sugar", "Pepper" };
    foreach (string x in myList)
    {
        string ingredient = ingredients.FirstOrDefault(x.Contains); // i.e., i => x.Contains(i)
        if (ingredient != null)
        {
            MessageBox.Show("The ingredient found in this line of myList is: " + ingredient);
        }
    }
