    public void Test<T>(List<T> rEntity)
    {
        var idProp = typeof(T).GetProperty("Id");
        if(idProp != null)
        {
           object id = 1;
           var result = rEntity.Where(x => idProp.GetValue(x).Equals(id));
        }
    }
