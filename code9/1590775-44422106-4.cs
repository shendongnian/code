    public static void PrintItems(IEnumerable items, int indentAmount = 0)
    {
        var indent = new string('\t', indentAmount);
        foreach (var item in items)
        {
            if (item is ICollection)
            {
                var innerItems = item as IEnumerable;
                Console.WriteLine($"{indent}Collection type encountered:");
                PrintItems(innerItems, indentAmount + 2);
            }
            else
            {
                Console.WriteLine($"{indent}{item}");
            }
        }
    }
