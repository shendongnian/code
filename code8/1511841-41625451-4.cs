    const int ProcessIncrement = 5000;
	
    void ProcessItems(ICollection<Person> people, bool force)
    {
        if (people == null || people.Count == 0)
            return;
        if (people.Count >= ProcessIncrement || force)
        {
            // Remove and process the items, possibly on a different thread.
            Console.WriteLine(string.Format("Processing {0} people." people.Count));
            people.Clear();
        }
    }
