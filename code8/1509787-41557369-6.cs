    public static void DisplayList<T>(IList<T> list)
    {
        foreach (T element in list)
        {
            Console.WriteLine(element);
        }
    }
