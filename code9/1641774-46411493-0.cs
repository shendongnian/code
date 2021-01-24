    public IEnumerable<ExampleClass> GetAll(string bValue)
    {
        foreach (var item in repo.GetAll())
        {
            item.B = bValue;
            yield return item;
        }
    }
