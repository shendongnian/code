    void displayAsChar(string badValue)
    {
        char[] values = badValue.ToCharArray();
        for (int i = 0; i < values.Length; i++)
        {
            string tempResult = "Value at index " + i + " is: " + values[i];
            Debug.Log(tempResult);
        }
    }
