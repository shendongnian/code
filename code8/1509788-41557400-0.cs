    public static void DisplayList<T>(IList<T> list)
    {
        foreach (T element in list)
        {
            var interval = element as Interval;
            if (interval != null)
                DisplayInterval(interval);
            else
                Console.WriteLine(element);
        }
    }
