    public bool IsFizz(int input)
    {
        if (input % 9 == 0)
        {
            FizzCount++;                    //Add 1 to fizzCount
            return true;
        }
        else
            return false;
    }
