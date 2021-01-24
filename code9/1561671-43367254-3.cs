    public void Test<T>(List<T> rEntity)
    {
        var type = typeof(T);
        var idProp = type.GetProperty("Id");
        if(idProp != null)
        {
           object id = 1;
           var result = rEntity.Where(x => idProp.GetValue(x).Equals(id));
        }
    }
