    for (int i = 0, k; i < arr.Length; i++)
    {
        try
        {
            T value = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
            for (k = i; k > 0 && value.CompareTo(arr[k - 1]) < 0; --k) arr[k] = arr[k - 1];
            arr[k] = value;
        }
        catch (Exception ex)
        {
            Console.WriteLine("That stuff was not convertible!");
            Console.WriteLine("Error: " + ex.Message);
        }
       
    }
