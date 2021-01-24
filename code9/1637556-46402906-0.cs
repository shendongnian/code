    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Web;
    
    namespace ConsoleApp2
    {
       class Program
       {
          static void Main(string[] args)
          {
             var tag = new XElement
                    (
                       "script",
                       new XAttribute("type", @"text/javascript"),
                       "//",
                       new XCData(@"
    
        $().ready(onLoad);
        
        function onLoad()
        {
           if (3 > 1){
             alert('Hello world');
           }
        };//")
                    );
    
             
             Console.WriteLine(tag.ToString());
    
             Console.ReadKey();
          }
       }
    }
