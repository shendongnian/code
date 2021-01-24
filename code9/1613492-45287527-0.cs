        List<int> listOfHexValues = new List<int>();
        var anArray = File.ReadAllLines(yourPath);
        foreach (string hexStr in anArray)
        {
            try
            {
                int hex = int.Parse(temp, System.Globalization.NumberStyles.HexNumber);
                listOfHexValues.Add(hex);
            }
            catch
            {
                //the line wasn't a valid integer.
            }
        }
