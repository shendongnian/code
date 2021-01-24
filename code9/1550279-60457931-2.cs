    IEnumerable<string> enumerable = Iterator();
    using (IEnumerator<string> enumerator = enumerable.GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            string value = enumerator.Current;
            Console.WriteLine("Received value: {0}", value);
            if (value != null)
            {
                break;
            }
        }
    }
