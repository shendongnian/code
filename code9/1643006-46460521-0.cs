    public partial class MainWindow : Window
    {
        public static int QntTodinho { get; set; }
        public MainWindow()
        {
        }
        private void Salgadinho_Click(object sender, RoutedEventArgs e)
        {
            Dinheiro22.Content = this.QntTodinho.ToString();
        }
     }
    public partial class Cidade : Window
    {
        private int qntTodinho = 0;
        private void todinhobotao_Click(object sender, RoutedEventArgs e)
        {
            TodinhoBotaoo();
        }
        public void TodinhoBotaoo()
        {
             this.qntTodinho += 1;
             MainWindow.QntTodinho = this.qntTodinho;
        }
    }
