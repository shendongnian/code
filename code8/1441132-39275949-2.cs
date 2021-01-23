     private IDictionary<string, string> foo<TModel>(IEnumerable<string> items,
      IEnumerable<TModel> otherItems,
      Func<TModel, String> FieldToUse) where TModel : BaseModel
    {
      //this will return a list of key value pairs of rowIDs and equipment
      IDictionary<string, string> x = (from o in otherItems
                                       join i in items on FieldToUse(o) equals i //joining on the equipment assetcode
                                       select new { rowID = o.RowID, item = i })
                                       .ToDictionary(k => k.rowID.ToString(), v => v.item);
      return x;
    }
    class BaseModel
    {
      public int RowID { get; set; }
    }
    class Model : BaseModel
    {
      public string Field1 { get; set; }
      public string Field2 { get; set; }
    }
