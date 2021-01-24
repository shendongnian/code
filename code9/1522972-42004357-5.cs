    [Table("RacasConteudo")]
    public partial class RacaConteudo
            ^^^^^
    {
       /* public RacaConteudo(...)  {} */
       
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public long RacaConteudoId { get; set; }
       ....
    }
