     if (!cellV.Contains("="))
     {
           continue;
     }
      //if contain P =, replace P= with "" coz only want the value, don want the P = for calculation
     if (cellV.Contains("P = "))
     {
             cellV = cellV.Replace("P = ", "");
     }
     if (cellV.Contains("F = n/a"))
     {
             cellV = cellV.Replace("F = n/a", "0");
     }
     if (cellV.Contains("F = "))
     {
             cellV = cellV.Replace("F = ", "");
     }
     if (cellV.Contains(" ; "))
     {
              cellV = cellV.Replace(" ; ", "");
     }
                Console.WriteLine(cellV);
