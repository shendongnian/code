    public static int GetNextId(List<object> param)
    {
        int id = param.OfType<Person>().Last().Id;
        return ++id;
    }
