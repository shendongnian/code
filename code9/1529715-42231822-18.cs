    public static void ProceesData<T>(IList<T> param1, string date1, string parameter)
    {
        Parallel.ForEach(param1, (currentItem) =>
        {
            // I want to aceess CustID property of param1 and pass that value to another function
            var value = typeof(T).GetProperty(parameter).GetValue(currentItem);
            Console.WriteLine("Value: " + value);
        });
    }
