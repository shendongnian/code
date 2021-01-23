    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("../../XMLFile1.xml");
            doc.Root.Sort(el => (string)el.Attribute("bar"));
            doc.Save(Console.Out);
        }
    }
    
    public static class MyExt
    {
        public static void Sort<TKey>(this XElement input, Func<XElement, TKey> selector)
        {
            input.Elements().ToList().ForEach(el => el.Sort(selector));
            input.ReplaceNodes(input.Elements().OrderBy(selector));
        }
    }
