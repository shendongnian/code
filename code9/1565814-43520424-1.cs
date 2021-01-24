    int CountValues(string input, string searchedValue)
    {
                    int numberOfSearchedValue= 0;
                    string line;
        using (StreamReader reader = new StreamReader (input))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if(line.Split(';')[1] == searchedValue)
                        numberOfSearchedValue++;
                    }
                }
          return numberOfSearchedValue;
    }
