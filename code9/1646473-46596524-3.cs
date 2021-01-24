    int index = 0;
    foreach (char c in s)
    {
        int result;
        if (int.TryParse(c, out result))
        {
            index = result;
            break;
        }
        //or if (char.IsDigit()) { index = int.Parse(c); break; }
     }
     ...
