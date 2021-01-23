    public class Test
       {
           private Action<int> hiddenMethod = new Action<int>((i) =>
           {
               Console.WriteLine(i);
           });
        
           public void PublicMethod(int i)
           {
               hiddenMethod(i);
           }
       }
