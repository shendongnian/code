        public async void AdicionaProduto(object sender, EventArgs e)
            {
                var al = ((MenuItem)sender);
                var produtoLista = new ListasView(al.CommandParameter as Produto);
                await Navigation.PushAsync(produtoLista);
            }
