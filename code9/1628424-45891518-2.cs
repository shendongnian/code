    public class AddressModel {
        public string Address1 { get; set; } //this is a strongly typed property
        public int Zip { get; set; } //this is a strongly typed property
    }
    
    public List<AddressModel> GetAddress(int addressId) {
        List<AddressModel> addressList = new List<AddressModel>();
        cmd.CommandText = @"SELECT Address1, Zip FROM [dbo].[Address]";
        using (SqlDataReader data = cmd.ExecuteReader())
        {
            while (data.Read())
            {
                AddressModel temp = new AddressModel();
                temp.Address1 = Sql.Read<String>(data, "Address1");
                temp.Zip = Sql.Read<Int32>(data, "Zip");
            }
        }
        return addressList;
    }
    
    public static class Sql
    {
        public static T Read<T>(DbDataReader DataReader, string FieldName)
        {
            int FieldIndex;
            try { FieldIndex = DataReader.GetOrdinal(FieldName); }
            catch { return default(T); }
    
            if (DataReader.IsDBNull(FieldIndex))
            {
                return default(T);
            }
            else
            {
                object readData = DataReader.GetValue(FieldIndex);
                if (readData is T)
                {
                    return (T)readData;
                }
                else
                {
                    try
                    {
                        return (T)Convert.ChangeType(readData, typeof(T));
                    }
                    catch (InvalidCastException)
                    {
                        return default(T);
                    }
                }
            }
        }
    }
