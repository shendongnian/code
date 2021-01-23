    if (sArray1[0] == sArray2[0] && sArray1[1] == sArray2[1])
    {
       var sArray12 = new [] { sArray1[0], sArray1[1] }
                          .Concat(sArray1.Skip(2))
                          .Concat(sArray2.Skip(2))
                          .Where(x => !string.IsNullOrEmpty(x)) //probably
                          .ToArray();
    }
