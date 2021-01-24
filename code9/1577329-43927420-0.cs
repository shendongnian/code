    namespace CadastroProdutos
    {
        public class Produto : INotifyPropertyChanged
        {
            private string codigo;
            public string Codigo 
            { 
                get {return codigo;} 
                set {codigo=value; OnPropertyChanged(); }
            }
            private string identificacao;
            public string Identificacao 
            { 
                get {return identificacao;} 
                set {identificacao=value; OnPropertyChanged(); }
            }
            private string tipo ;
            public string Tipo 
            { 
                get {return tipo;} 
                set {tipo=value; OnPropertyChanged(); }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
