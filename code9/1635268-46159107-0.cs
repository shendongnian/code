    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void button_Voltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        private readonly ObservableCollection<Cliente> clientes = new ObservableCollection<Cliente>();
        private void button_Listar_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Rui\Documents\Visual Studio 2015\Projects\Gestão Clientes Empresas\dadosClientes.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                Cliente a = new Cliente();
                a.Nome = parts[0];
                a.Nif = parts[1];
                a.Morada = parts[2];
                clientes.Add(a);
            }
            listView.ItemsSource = clientes;
        }
        private bool myTextFilter(object item)
        {
            if (String.IsNullOrEmpty(textBox_pesquisa.Text))
                return true;
            var cliente = (Cliente)item;
            return (cliente.Nome.StartsWith(textBox_pesquisa.Text, StringComparison.OrdinalIgnoreCase));
        }
        private void textBox_pesquisa_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.Filter = new Predicate<object>(myTextFilter);
        }
        private void button_Apagar_Click(object sender, RoutedEventArgs e)
        {
            Cliente client = listView.SelectedItem as Cliente;
            if(client != null)
                clientes.Remove(client);
        }
    }
