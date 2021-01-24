    public class CICO
    {
        public double? ssn_or_tin { get; set; }
        public double? cusid { get; set; }
        public double? accountNo { get; set; }
        public string dateTrans { get; set; }
        public int? transCode { get; set; }
        public string transdescription_1 { get; set; }
        public double? amount { get; set; }
        public double? cashin { get; set; }
        public double? cashout { get; set; }
        public string source { get; set; }
        public int SSN { get; set; }
    }
    public class SearchParameters
    {
        public string ssn_or_tin { get; set; }
        public SearchParameters()
        {
            this.ssn_or_tin = string.Empty;
        }
        internal List<SqlParameter> ToSqlParameterList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ssn_or_tin",  this.ssn_or_tin??string.Empty));
            return parameters;
        }
    }
