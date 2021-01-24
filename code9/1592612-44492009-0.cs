    for (var i = 0; i <= 9; i++)
     {
        try
         {
          bytPixle24[i] = Convert.ToByte(pixel24[i]);
         }
        catch (System.OverflowException ex)
         {
           // ...
         }
     }
