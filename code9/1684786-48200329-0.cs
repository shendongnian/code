    public int GetNumberByIndex(char index)
    {
        try
        {
            Convert.ToInt32(index);
        }
        catch
        {
            throw new FormatException(IndexIsNotANumber);
        }
    }
