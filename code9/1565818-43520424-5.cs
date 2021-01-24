    int CountValues(string input, string searchedValue, int ColumnNumber, bool skipFirstLine = false)
    {
                    int numberOfSearchedValue= 0;
                    string line;
                using (StreamReader reader = new StreamReader (input))
                {
                    if(skipFirstLine)
                        reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    {
                        if(line.Split(';')[ColumnNumber] == searchedValue)
                           numberOfSearchedValue++;
                    }
                }
          return numberOfSearchedValue;
    }
