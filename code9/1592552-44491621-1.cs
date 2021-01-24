    private static void ShowFamily(Person person, int indent = 0)
    {
        var indentLines = new string('-', indent);
        Console.WriteLine(indentLines + person.Name);
        if (person is Parent)
        {
            var parent = person as Parent;
            foreach(var child in parent.Children)
            {
                ShowFamily(child, indent + 2);
            }
        }
    }
