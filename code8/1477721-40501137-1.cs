    public class Designation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int  id  { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int DepartmentID { get; set; }
        public bool IsActive { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual  Department Department { get; set; }
    }
