    foreach (DictionaryEntry item in od)
    {
        if (item.Value is string[])
        {
            foreach (string str in (string[])item.Value)
            {
                Console.WriteLine("A string item: " + str);
            }
        }
    }
