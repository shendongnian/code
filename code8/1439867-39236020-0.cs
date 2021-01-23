    private List<int> GetLessThanOrDivisbleBySeven(int num)
    {
       List<int> ReturnList = new List<int>();
       // Add all the numbers that are less than 7 first
       int i = 0;
       for(i = 0; i < 7; i++)
          ReturnList.Add(i);
       int res = num / 7;// num = res*7+rem
       for(i = 1; i <= res; i++)
       {
           ReturnList.Add(i*7);
       }
       return ReturnList;
     }
