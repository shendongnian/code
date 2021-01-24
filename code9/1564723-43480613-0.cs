    for (int i = 0; i < z; i++)
    {
        if (i == 0)           // 1st case (left border)
        {
            n[0].AbsValue = Math.Abs(n[1].Value - n[0].Value);
        }
        else if(i == (z-1))  // 2nd (please, notice "else if") (right border)
        {
           n[z-1].AbsValue = Math.Abs(n[z-1].Value - n[z -2].Value);
        }
        else // 3d (inner values)
        {
        ....
        }
