    [StepArgumentTransformation]
    public IEnumerable<T> Entity_Transform<T>(Table table)
    {
        return table.CreateSet<T>();
    }
