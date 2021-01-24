    public int GetNumberByIndex(char index)
    {
        try
        {
            //Convert.ToInt32(index);
            int.Parse(index.ToString());
        }
        catch
        {
            throw new FormatException(IndexIsNotANumber);
        }
    }
