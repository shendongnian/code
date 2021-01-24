    public static class ResultFactory
    {
        public static Result<T, TU> Create<T, TU>(TU success, T data)
        {
            return new Result<T, TU> { success = success, Data = data };
        }
    }
    var result = ResultFactory.Create(true, 88);
    var result2 = ResultFactory.Create(true, "Niels");
