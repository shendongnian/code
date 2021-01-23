    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SO39543589
    {
    
      public interface ISecondTyper
      {
        string Type { get; }
      }
    
      // Define other methods and classes here
    
      public class BaseFilter
      {
        public virtual string Type { get { return "ABC"; } }
      }
    
      public class Filter1 : BaseFilter
      {
        public new virtual string Type { get { return "DEF"; } }
      }
    
      public class Filter2 : Filter1, ISecondTyper
      {
        string ISecondTyper.Type
        {
          get
          {
            return (this as BaseFilter).Type;
          }
        }
        public override string Type { get { return "X"; } }
      }
    
      class Program
      {
        static void Main()
        {
          BaseFilter abc = new Filter2();
          Console.WriteLine(abc.Type);
    
          Filter1 d = new Filter2();
          Console.WriteLine(d.Type);
    
          Filter2 e = new Filter2();
          Console.WriteLine(e.Type);
    
          ISecondTyper st = e;
          Console.WriteLine(st.Type);
    
          Console.WriteLine("END");
          Console.ReadLine();
        }
      }
    }
