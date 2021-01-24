     class Program
     {
        static void Main(string[] args)
        {
            var operationContext = new OperationContext();
            var elements = xml.Elements().ToList();
            foreach (var element in elements)
            {
                operationContext.GetOperationData(element.Name, element);
            }
        }
    }
