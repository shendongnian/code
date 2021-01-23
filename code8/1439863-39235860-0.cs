    int oldMax = 0;
    List<int> ReturnList = new List<int>();
    private List<int> GetLessThanOrDivisbleBySeven(int num)
    {
           if (num > oldMax )
           {
               oldMax  = num;
               for(int i = oldMax ; i <= num; i++)
               {
                  if(i <7 || i % 7 == 0)
                  {
                     ReturnList.Add(i);
                   }
                }
                  return ReturnList;
           }
           else 
           {
                // crate a copy of ReturnList  and Remove from  ReturnList numbers bigger than num
           }
    } 
