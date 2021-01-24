    public static void PrintItem(object item, int indentAmount = 0)
    {
        var indent = new string('\t', indentAmount);
        if (item == null) Console.WriteLine($"{indent}<null>");
        if (item is ICollection)
        {
            var innerItems = item as IEnumerable;
            Console.WriteLine($"{indent}Collection type encountered:");
            indentAmount++;
            foreach (var innerItem in innerItems)
            {
                PrintItem(innerItem, indentAmount);
            }
        }
        else
        {
            Console.WriteLine($"{indent}{item}");
        }
    }
