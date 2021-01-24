    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int MarcaId { get; set; }     
        public virtual Marca Marca { get; set; }
    }
