    public static bool Between(DateTime input, int x, int y)
    {
        return (input.Hour => x && input.Hour <= y);
    }
    var result = myList.Where(item => item.date.Between(7, 15));
