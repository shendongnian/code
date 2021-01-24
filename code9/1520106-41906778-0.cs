    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement doc = new XElement("QmlDiv", new object[] {
                    new XElement("class1", new object[] {
                        new XElement("class2",divToTransform.innerContent)
                    }),
                });
            }
        }
    }
