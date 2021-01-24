    public  class tbl_UAM
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName {get; set;}
        // the rest of columns
   }
