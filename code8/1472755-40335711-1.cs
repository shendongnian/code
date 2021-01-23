    PedidoBLL pedido = new PedidoBLL();
    txtName.AutoCompleteMode = AutoCompleteMode.Suggest;
    txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
    AutoCompleteStringCollection popula = new AutoCompleteStringCollection();
    popula.AddRange(pedido.LoadList().ToArray());
    txtName.AutoCompleteCustomSource = popula;
