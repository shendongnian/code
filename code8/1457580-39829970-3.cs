    public void InitFieldList()
    {
        foreach (var item in DbFieldList)
        {
            Fields.Add(FieldInitializers[item.Type].Invoke());
        }
    }
