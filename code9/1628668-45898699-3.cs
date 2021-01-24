    using System;
    
    public class Test
    {
        public static void Main()
        {
            string scrapedElement = "test test .html test";
            string [] Test =new string[scrapedElement.Contains(".html")?2:1];
            Test[0] = scrapedElement;
    
        }
        
    }
