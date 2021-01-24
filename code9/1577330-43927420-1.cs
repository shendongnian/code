    namespace CadastroProdutos
    {
        public class ListProdutoViewModel
        {
            ObservableCollection<Produto> produtos;
            public ListProdutoViewModel()
            {
                produtos = new ObservableCollection<Produto>();
            }
            public ObservableCollection<Produto> Produtos
            {
                set
                {
                    if (value != produtos)
                    {
                        produtos = value;
                    }
                }
                get
                {
                    return produtos;
                }
            }
        }
    }
