    public void Generate()
    {
        Fill();
        while(!Fleet())
        {
            // I assume Fill clears your board again?!
            Fill();
        }
    }
    public bool Fleet()
    {
        return Ship2(Utility.R(1,9),Utility.R(1,9),Utility.R(4)) &&
               Ship3(Utility.R(1,9),Utility.R(1,9),Utility.R(4)) &&
               Ship3(Utility.R(1,9),Utility.R(1,9),Utility.R(4)) &&
               Ship4(Utility.R(1,9),Utility.R(1,9),Utility.R(4)) &&
               Ship5(Utility.R(1,9),Utility.R(1,9),Utility.R(4));
    }
    public bool Ship2(int x, int y, int r)
    {
        if (r == 0)
        {
            return CreateShip(x, y) &&
                   CreateShip(x, (y + 1));
        }
        if (r == 1)
        {
            return CreateShip(x, y) &&
                   CreateShip(x, (y + -1));
        }
        if (r == 2)
        {
            return CreateShip(x, y) &&
                   CreateShip((x-1), (y));
        }
        if (r == 3)
        {
            return CreateShip(x, y) &&
                   CreateShip((x+1), (y));
        }
        return false;
    }
    public void CreateShip(int x, int y)
    {
        if (x <= 9 && y <= 9 && x >= 0 && y >= 0)
        {
            if (Board[x, y] == 'L')
            {
                return false;
            }
            else
            {
                Board[x, y] = 'L';
            }
        }
        else
        {
            return false;
        }
        return true;
    }
