    void Dodge(List<List<T>> domains)
    {
        Fuski(domains, new List<T>());
    }
    void Fuski(List<List<T>> domains, List<T> vector)
    {
        if (domains.Count == vector.Count)
        {
            Console.WriteLine(string.Join("", vector)); 
            return;
        }
        foreach (var value in domains[vector.Count])
        {
            var newVector = vector.ToList();
            newVector.Add(value);
            Fuski(domains, newVector);
        }
    }
