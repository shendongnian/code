    MyResponseModel<T>
    {
         public int TotalCount { get; set; }
         public IEnumerable<T> Data { get; set; }
    }
