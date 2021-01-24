    using System.ComponentModel.DataAnnotations;
    public class Location
    {
        [Required()]
        public int MCC { get; set; }
        [Required()]
        public int MNC { get; set; }
        [Required()]
        public int LAC{ get; set; }
        [Required()]
        public int CellId { get; set; }
    }
