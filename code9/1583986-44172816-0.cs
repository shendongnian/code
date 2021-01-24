    public void DisplayA(A value)
    {
        Console.WriteLine(value.Name);
        foreach (var child in value.Children.OrderBy(c => c.Name))
        {
            Console.WriteLine(string.Format("- {0}", child.Name));
        }
    }
