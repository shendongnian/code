        public string Filter
        {
            get { return _Filter; }
            set {
                MainVM.Modules.AllModules[0].Vwr.Table.dv.RowFilter = "PN LIKE '%" + _Filter + "%'";
                _Filter = value; OnPropertyChanged(nameof(Filter)); }
        }
        private string _Filter = "";
