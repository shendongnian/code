    using IdType = System.Guid;
    using RowType = System.Tuple<System.Guid, object>;
    
    namespace WindowsFormsApplication1
    {
    public void Test()
    {
      var guideq = typeof(IdType).Equals(typeof(System.Guid));
      var typeeq=typeof(RowType).Equals(typeof(System.Tuple<System.Guid,
      object>));
      System.Tuple<System.Guid, object> obj = new RowType(IdType.NewGuid(), "");
    }
