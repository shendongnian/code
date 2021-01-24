    public static class DapperExstensionsExstensions
    {
        public static Type SharedState_ModelInstanceType { get; set; }
        ...
    }
    
    IDb obj = new DbModel();
    DapperExstensionsExstensions.SharedState_ModelInstanceType = obj.GetType();
    sqlConnection.Insert(obj);
