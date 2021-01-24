    //Child will have one parent.
    class Child
    {
        [Key]
        public int ChildId { get; set; }
        public string ParenChildName {get; set; }
        public int ParentId {get; set; }
        [ForeignKey("ParentId")]
        public virtual Parent Parent{ get; set; }
    }
