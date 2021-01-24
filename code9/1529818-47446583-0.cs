    class A
    {
        [PrimaryKey]
        public int A_ID { get; set; }
        [OneToMany(CascadeOperations=CascadeOperation.All)]
        public List<B> Children { get; set; }
    }
    class B
    {
        [PrimaryKey]
        public int B_ID { get; set; }
        [OneToOne(ReadOnly=true)]
        public C C_Obj { get; set; }
        [ForeignKey(typeof(C))]
        public int C_ID { get; set; }
    }
    class C
    {
        [PrimaryKey]
        public int C_ID { get; set; }
    } 
