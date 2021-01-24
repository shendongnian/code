    try
    {
         List<int> i = new List<int>() { 1, 2, 3, 5, 7, 8, 11, 13, 14 };
         int istart = i[0];
         bool flag = false;
         string range = string.Empty;
         for(int index = 0;index<i.Count-1;index++)
         {
             if ((i[index] + 1) == i[index + 1])
             {
                  flag = true;
                  continue;
             }
             else
             {
                  if (!flag)
                      Console.Write(istart);
                  else
                      Console.Write(istart + "-" + i[index]);
                  Console.Write(",");
                  flag = false;
                  istart = i[index + 1];
              }
          }
          if (istart + 1 == i[i.Count - 1])
              Console.Write(istart + "-" + i[i.Count - 1]);
          else
              Console.WriteLine(istart);
    }
    catch(Exception ex)
    {
           Console.WriteLine(ex.Message);
    }
    Console.WriteLine();
    Console.WriteLine("Done");
    Console.Read();
