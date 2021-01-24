    public class PostEmpData
    {
        public string cExternalGUID { get; set; } = "10134";
        public string cEmployeeID { get; set; } = "10134";
        public string cLastName { get; set; } = "Anderson";
        public string cFirstName { get; set; } = "Derek";
        public string cAccessGroup { get; set; } = "";
        public string cActive { get; set; } = "A";
        public int nCardNumber { get; set; } = 10134;
        public int nPayMethod { get; set; } = 2;
        public string[] cGroupsList  { get; set; }= new string[0] { };
        public DateTime dHireDate  { get; set; }= DateTime.Parse("1999 / 11 / 03");
        public DateTime dTermDate  { get; set; }= DateTime.Parse("01 / 01 / 0001");
        public DateTime dRateEffectiveDate  { get; set; }= DateTime.Parse("2017 - 07 - 15");
        public decimal nPayRate  { get; set; }= 1500;
    }
