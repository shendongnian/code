    class Folder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FolderID { get; set; }
        public int? ParentFolderID { get; set; }
        [ForeignKey("ParentFolderID")]
        public Folder ParentFolder { get; set; }
        ...
    }
