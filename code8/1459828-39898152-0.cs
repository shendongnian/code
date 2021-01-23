	Application.Current.Dispatcher.Invoke(() =>
	{		
		///....
			System.Windows.Window historicoEmailCadastro = new System.Windows.Window
			{
				Title = "Cadastro de Histórico de Email",
				Content = new HistoricoEmailCadastro(listaPendenciaId),
				Width = 249,
				Height = 213,
				ResizeMode = ResizeMode.NoResize
			};
		historicoEmailCadastro.ShowDialog();
	});
