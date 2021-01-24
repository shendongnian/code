    public class Departement
    {
        [JsonProperty("org.MainDepartments")]
        public IList<Departaments> MainDepartments { get; set; }
    }
    public class Departaments
    {
        [JsonProperty("@MainDepartmentsId")]
        public string DpId { get; set; }
        [JsonProperty("@MainDepartmentsName")]
        public string DpName { get; set; }
        [JsonProperty("@MainDepartmentsName_En")]
        public string DpNameEn { get; set; }
        [JsonProperty("org.WorkAreas")]
        public IList<WorkAreas> WorkAreas { get; set; }
    }
    public class WorkAreas
    {
        [JsonProperty("@Id")]
        public string WorkId { get; set; }
        [JsonProperty("@Name")]
        public string WorkName { get; set; }
        [JsonProperty("@WorkAreasName_En")]
        public string WorkNameEn { get; set; }
        [JsonProperty("org.LIfBiDepartments")]
        public LIfBiDepartments LIfBiDepartments { get; set; }
    }
    public class LIfBiDepartments
    {
        [JsonProperty("@LIfBiDepartmentsId")]
        public string BiDpId { get; set; }
        [JsonProperty("@LIfBiDepartmentsName")]
        public string BiDpName { get; set; }
        [JsonProperty("@LIfBiDepartmentsName_En")]
        public string BiDpNameEn { get; set; }
    }
    
    Use a property in the parent class to call the object's deserializer in 
    daughters classes. 
    Example:
        [JsonProperty("Departementstructure")]
        public Departement MainDepartement { get; set; }
    Output:
