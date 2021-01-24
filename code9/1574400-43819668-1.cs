    for (int r = 0; r < rowAmount; ++r)
    {
      for (int n = 0; n < numAmount; ++n)
      {
        userNum = lotRng.Next(1, numAmount * rngMult);
        
        for (int x = 0; x < coupon.GetLength(1); x++) //Iterate over your second dimension again
        {
          while (coupon[r,x] == userNum)
          {
            userNum = lotRng.Next(1, numAmount * rngMult);
          }
        }
        coupon[r, n] = userNum;
      }
    }
