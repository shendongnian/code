    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Runtime;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication42
    {
        class Program
        {
            static void Main(string[] args)
            {
                Foo x = new Foo { Bar = "Hi", Fred = "hey yourself" };
                //<Foo>
                //   <Bar>Hi</Bar>
                //   <John>                         <!-- Note extra layer -->
                //       <Fred>hey there</Fred>
                //   </John>
                //</Foo>
                XElement foo = new XElement("Foo", new object[] {
                    new XElement("Bar", x.Bar),
                    new XElement("John", new XElement("Fred", x.Fred))
                });
            }
        }
        public class Foo
        {
            public string Bar { get; set; }
            public string Fred { get; set; }
        }
     
    }
