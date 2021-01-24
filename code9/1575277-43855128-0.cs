    [Table("NotasAdjuntas")]
    public class NotasAdjuntas
    {
        public int Id { get; set; }
        ....
        [Required]  //<<<<< add this
        public virtual Local local { get; set; }
        ....
    }
