    public int SumMyObjects(List<object> objs)
    {
       int sum =0;
       foreach(var obj in objs)
       {
          try
          {
            sum += Convert.ToInt32(obj);
          }
          catch
          {
             // obj wasn't a valid int
          }
       }
       return sum;
    }
