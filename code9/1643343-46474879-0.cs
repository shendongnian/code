    public class Computers
    {
        public string ComputerID { get; set;}
        public string Maker { get; set;}
        public string PONumber { get; set; }
        public string SerialNumber { get; set; }
        public Boolean DimantleFlag { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class Parts
    {   
        public string PartID { get; set; }
        public string PONumber { get; set; }
        public string SerialNumber { get; set; }
        public string PartDescription { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class ComputerParts
    {
        public string ComputerID { get; set; }
        public string PartID { get; set; }
        public Boolean Current { get; set; }
        public DateTime DateCreated { get; set; }
    }
