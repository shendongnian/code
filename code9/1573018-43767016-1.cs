    public static string ShowGibberish(int num)
    {
        if (num == 0) { return ""; }
        else {
             if (num % 2 == 0) {return "%" + ShowGibberish(num-1);}
             else {return "#" + ShowGibberish(num-1);}
        }
    }
