    private static void Dump(XElement element, int level)
    {
        var space = new string(' ', level * 4);
        if (element.HasElements)
        {
            Console.WriteLine("{0}startParent_{1}", space, element.Name);
            foreach (var child in element.Elements())
            {
                Dump(child, level + 1);
            }
            Console.WriteLine("{0}endParent_{1}", space, element.Name);
        }
        else
        {
            Console.WriteLine("{0}{1}", space, element.Name);
        }
    }
