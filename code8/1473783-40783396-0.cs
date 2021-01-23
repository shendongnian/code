    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using WatiN.Core;
    
    namespace WatinTest
    {
      class Program
      {
        [STAThread]
        static void Main(string[] args)
        {
          var ie = IE.AttachTo<IE>(Find.ByTitle(new Regex(".*")));
          foreach (var div in ie.Divs)
          {
            Console.WriteLine(div.IdOrName);
          }
          Console.ReadLine();
        }
      }
    }
 
