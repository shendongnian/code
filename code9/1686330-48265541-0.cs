    [Table("ReferenciasFabricante", Schema = "public")]
    public class ReferenciaFabricante
    {
        [Key]
        public int Id { get; set; }
        ...
        
        //JOIN TABLE
        [InverseProperty("ReferenciaFabricante")]
        public IList<ReferenciaFabricanteTieneReferenciaConstructor> ReferenciaFabricanteTieneReferenciaConstructor { get; set; }
    }
    [Table("ReferenciasConstructor", Schema = "public")]
    public class ReferenciaConstructor
    {
        [Key]
        public int Id { get; set; }
        ...
        //JOIN TABLE
        [InverseProperty("ReferenciaConstructor")]
        public IList<ReferenciaFabricanteTieneReferenciaConstructor> ReferenciaFabricanteTieneReferenciaConstructor { get; set; }
    }
    //JOIN TABLE
    [Table("ReferenciaFabricanteTieneReferenciaConstructor", Schema = "public")]
    public class ReferenciaFabricanteTieneReferenciaConstructor {
        [Key]
        public int IdReferenciaFabricante { get; set; }
        [ForeignKey("IdReferenciaFabricante")]
        public ReferenciaFabricante ReferenciaFabricante { get; set; }
        [Key]
        public int IdReferenciaConstructor { get; set; }
        [ForeignKey("IdReferenciaConstructor")]
        public ReferenciaConstructor ReferenciaConstructor { get; set; }
    }
