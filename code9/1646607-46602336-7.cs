    bool Populate(IDataReader reader)
    {
         var obj = new MyClass();
         while(reader.Read())
         {
             obj.PropertyA = reader.GetValueOrDefault("A"); // That method is written in the IDataReaderExtestion class in ADONETHelper
         }
        return true;
    }
