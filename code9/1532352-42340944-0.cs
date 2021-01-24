	static bool isValid(string s)
    {
        int oldValue = int.MinValue;
        int consecutiveCounter = 0;
        foreach (char item in s)
        {
            if(Math.Abs((int)item - oldValue) <= 1)
            {
                consecutiveCounter++;
                oldValue = (int)item;
                if (consecutiveCounter == 2)
                    return true;
                else
                    continue;
            }
            oldValue = (int)item;
            consecutiveCounter = 0;
        }
        return false;
    }
    
