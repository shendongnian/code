    public class Item : IRegistrable { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public EstadoRegistrable Estado { get; set; }
        public int ProductoID { get; set; }
        [ForeignKey("ProductoID")]
        public virtual Producto ProductoObj { get; set; }
        [Required] [MaxLength(30)]
        public string Marca { get; set; }
        [ForeignKey("Marca")]
        public Marca MarcaObj { get; set; }
        [DecimalPrecision(9,3)]
        public decimal Tamaño { get; set; }
        [MaxLength(100)]
        public string Complemento { get; set; }
        [MaxLength(500)]
        public string Descripción { get; set; }
    }
