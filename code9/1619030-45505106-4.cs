    var biggestLength1 = Math.Max(array1.Length, array2.Length);   
    for (int a = 0; a < biggestLength1; a++)   
    {
        for (int b = 0; b < Math.Max(array1[a].Length, array2[a].Length); b++)     
        {
            if (a < array1.Length && 
                a < array2.Length && 
                b < array1[a].Length && 
                b < array2[a].Length)
            {
                // every array has enough element quantity
                //can do operation with both arrays
            }
            else
            {
                //some array is bigger                           
            }
        }
    }
