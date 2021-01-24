    private static void ShowFamily(Person person, int indent = 0)
    {
        var indentLines = new string(' ', indent);
        if (person is Parent)
        {
            Console.WriteLine(indentLines + "*" + person.Name);
            var parent = person as Parent;
            foreach (var child in parent.Children)
            {
                ShowFamily(child, indent + 2);
            }
        }
        else
        {
            Console.WriteLine(indentLines + "-" + person.Name);
        }
    }
