    public class GenericList<T>
    {
         public List<T> SerachFun(List<T> input, string search)
         {
                List<T> output = new System.Collections.Generic.List<T>();
                foreach (var aa in input)
                {
                   var columns = aa.GetType().GetProperties().ToList();
                   foreach (var bb in columns)
                   {
                      var cccc = bb.GetValue(aa);
                      if(cccc!=null)
                      {
                         bool result = cccc.ToString().Contains(search);
                         if (result)
                         {
                            output.Add(aa);
                            continue;
                          }
                      }
                  }
             }
                return output;
        }
      }
