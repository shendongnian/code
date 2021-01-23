    public static int GetNextMailNumber()
    {
        static DateTime currentDate = DateTime.Now;
        static int nextNumber = 1;
        var now = DateTime.Now;
        If(currentDate.Date.Equals(now.Date) == false)
        {
            currentDate = now;
            nextNumber = 1;
        }
        return nextNumber++;
    } 
