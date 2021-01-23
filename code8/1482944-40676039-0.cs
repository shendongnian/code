    public class PedidoVenda {
    
        private ISet<ItemPedidoVenda> _itens = new HashedSet<ItemPedidoVenda>();
    
        // The public property which returns the collection is a REadOnlyCollection so the user cannot mess around with it.
        public ReadOnlyCollection<ItemPedidoVenda> Itens 
        { 
            get 
            {
               return new List<ItemPedidoVenda>(_itens).AsReadOnly();
            } 
        }
     
        public void AddPedido( ItemPedidoVenda item )
        {
           if( _itens.Contains(item) == false )
           {
               item.Pedido = this; // Here, make sure that the reference is filled out.
               _itens.Add(item);
           }
        }
}
