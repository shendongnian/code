    public int Tax
    {
        get
        {
            if (Salary > 2000)
            {
                return 20;
            }
            else if (Salary > 1500)
            {
                return 10;
            }
            else
            {
                return 5;
            }
        }
    }
