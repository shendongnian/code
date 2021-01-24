    public class Device1ImportModel : IImportModel<Device1ImportModel>
    {
        public string SerialNumber { get; set; }
        public string PartA { get; set; }
        public List<Device1ImportModel> CreateImportList(SqlDataReader reader)
        {
