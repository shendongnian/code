        public RelayCommand<string> Command
        {
            get
            {
                return new RelayCommand<string>(parameter =>
                {
                    var str = parameter;
                });
            }
        }
