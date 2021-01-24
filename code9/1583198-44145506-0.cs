    [Table("MyTable")]
    public new class MyTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MyPrimaryKey { get; set; }
    }
