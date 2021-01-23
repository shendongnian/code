        private void Update() {
            Task.Run(new Action(() => {
                // somewhat lengthy operation
                _imageSource = FranjasSenoidais.Criar((int)franjas.Width,
                                       (int)franjas.Height,
                                       Maximo, Minimo,
                                       Espessura);
                RaisePropertyChanged("ImageSource");
            }));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string name) {
            Application.Current.Dispatcher.Invoke(() => {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }, System.Windows.Threading.DispatcherPriority.Background);
        }
