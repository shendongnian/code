    //called by the collectionView
    private bool UserFilter(object item)
    {
            string produtoItem;
             //my LB1. With dynamic type i am gettting the item selected. 
            dynamic selectProdutoItem = LbProdutoPlano.SelectedItem;
            produtoItem = selectProdutoItem.produtoPlanoNome;
            if (String.IsNullOrEmpty(produtoItem))
            {
                return true;
            }
            else
            {
                //this will filter based on my selected item on LB 1. fichaProduto is my class and fichaProdutoNome an string of the class that is the same string or item in LB1, produtoItem. 
                return ((item as fichaProduto).fichaProdutoProdutoNome.IndexOf(produtoItem, StringComparison.OrdinalIgnoreCase) >= 0);
            }
    }
    private ButtonAdd_Click()
    {
            CollectionView viewFiltro = (CollectionView)CollectionViewSource.GetDefaultView(LbProdutoPlanoEscolhido.ItemsSource);
             viewFiltro.Filter = UserFilter;
             if (viewFiltro.Count == 1)
             {
                 MessageBox.Show("Já existe produto Internet na lista escolhida");
             }
             else
             {
             // add the item into LB 2. 
             }
    }
