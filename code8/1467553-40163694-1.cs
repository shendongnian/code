    double a = 0;
    bool test = double.TryParse(dr.ItemArray[0].ToString(), out a);
    if (test)
    {
        int pot = (int)((a / 14) * 12.5);
    }
