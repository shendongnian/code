      private string _arquivoOrigem;
        public string ArquivoOrigem
        {
            get
            {
                return _arquivoOrigem;
            }
            set
            {
                _arquivoOrigem = value;
                OnPropertyChanged("ArquivoOrigem");
            }
        }
