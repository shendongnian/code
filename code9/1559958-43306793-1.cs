    [ServiceContract]
    interface IExcelService
    {
        [OperationContract]
        List<CustomExcelData> GetExcelData();
    }
    [DataContract]
    public class CustomExcelData
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        public CustomExcelData(DataRow row)
        {
            Name = row["NameField"].ToString();
            Address = row["AddressField"].ToString();
            BirthDate = DateTime.Parse(row["BirthDateField"].ToString());
        }
    }
