    public int ToOctal(int x)
    {
        if(x == 0)
        {
            return 0;
        }
        return x % 8 + 10 * ToOctal(x / 8);
    }
