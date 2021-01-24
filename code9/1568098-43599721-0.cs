    int counter = 0;
    foreach (List<decimal> result in results)
    {
           if(counter == 3) break;
           if (result.Count == NoDisplay)
           {
                recordexist = true;
                foreach (decimal value in result)
                {
                    Console.Write("{0}\t", value);
                }
                if (recordexist == true)
                {
    
                    Console.WriteLine();
                }
                counter++;
          }
    }
