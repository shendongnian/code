    [DataContract(IsReference = true)]
    public partial class brand_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public brand_Table()
        {
            this.branch_Table = new HashSet<branch_Table>();
            this.sale_Table = new HashSet<sale_Table>();
        }
        [DataMember]
        public int brand_id { get; set; }
        [DataMember]
        public string brand_name { get; set; }
        [DataMember]
        public string brand_imageUrl { get; set; }
        [DataMember]
        public int company_id { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<branch_Table> branch_Table { get; set; }
        [DataMember]
        public virtual company_Table company_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<sale_Table> sale_Table { get; set; }
    }
