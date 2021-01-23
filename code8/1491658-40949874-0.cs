    using System;
    using System.Xml.Linq;
    class Test
    {
        static void Main()
        {
            string xml = @"
                <root>
                    <child id='1'/>
                    <child id='2'>
                        <grandchild id='3' />
                        <grandchild id='4' />
                    </child>
                </root>";
            XDocument doc = XDocument.Parse(xml);
            foreach (XElement element in doc.Descendants("grandchild"))
            {
                Console.WriteLine(element);
            }
            XDocument doc = XDocument.Parse(xml); 
            IEnumerable<XElement> childList =  
                from el in doc.Elements()  
                select el;  
            foreach (XElement e in childList)  
                Console.WriteLine(e); 
            }
        }
    }
