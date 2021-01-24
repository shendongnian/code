    [DataContract]
    public class StudentInfo
    {
        [Key]
        [DataMember(Order = 0)]
        [StringLength(20)]
        public string StudentId { get; set; }
        [Key]
        [DataMember(Order = 1)]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Key]
        [DataMember(Order = 2)]
        [StringLength(20)]
        public string LastName { get; set; }
        [DataMember(Order = 3)]
        [StringLength(20)]
        public string ContactNumber { get; set; }
        [DataMember(Order = 4)]
        [StringLength(20)]
        public string Gender { get; set; }
        [DataMember(Order = 5)]
        [StringLength(20)]
        public string Course { get; set; }
        [DataMember(Order = 6)]
        public DateTime? CreatedDate { get; set; }
    }
