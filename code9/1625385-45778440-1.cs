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
                //this will do a comparative logic on my selected item on LB 1. fichaProduto is my class and fichaProdutoProdutoNome a string of that class that is the same string or the item in LB1, produtoItem. 
                return ((item as fichaProduto).fichaProdutoProdutoNome.IndexOf(produtoItem, StringComparison.OrdinalIgnoreCase) >= 0);
            }
    }
    // a button to add an item from LB1 to LB2. 
    private ButtonAdd_Click()
    {
            //created the collectionView in here having the itemSource the LB2 that is already binded. 
             CollectionView viewFiltro = (CollectionView)CollectionViewSource.GetDefaultView(LbProdutoPlanoEscolhido.ItemsSource);
             // this is the key of this logic. The View will do a comparative logic from the retur of the UserFilter method.
             viewFiltro.Filter = UserFilter;
             // so if the View found it, it will count 1. 
             if (viewFiltro.Count == 1)
             {
                 MessageBox.Show("This product is already in the LB2.");
             }
             else
             {
             // add the item into LB 2. 
             }
    }
