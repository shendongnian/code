    public partial class ResultadosBuscados : ContentPage {
        public ResultadosBuscados(IEnumerable dadosPesquisados) {
            IsBusy = false;
            InitializeComponent();
            BindingContext = this;
            ListaBuscados.ItemsSource = dadosPesquisados;
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            IsBusy = false;
        }
    }
