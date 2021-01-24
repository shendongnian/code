        public RelayCommand<SelectionChangedEventArgs> SelectionChangedCommand => new RelayCommand<SelectionChangedEventArgs>(SelectionChanged);
        public RelayCommand<RoutedEventArgs> ListBoxLoadedCommand => new RelayCommand<RoutedEventArgs>(ListBoxLoaded);
        private string CorrectionMatrixName { get; set; }
        private void ListBoxLoaded(RoutedEventArgs obj)
        {
            if (obj.Source is ListBox listBox)
            {
                listBox.SelectedIndex = 0;
            }
        }
        private void SelectionChanged(SelectionChangedEventArgs obj)
        {
            if (obj.AddedItems.Count <= 0) return;
            if (obj.AddedItems[0] is CorrectionMatrix matrix)
            {
                CorrectionMatrixName = matrix.name;
            }
            RaisePropertyChanged(() => CorrectionMatrixA);
        }
        public SimpleMatrix CorrectionMatrixA
        {
            get
            {
                try
                {
                    var x = Matrixes.Correction.Where(a => a.name == CorrectionMatrixName)
                                .Select(a => a.A).Single();
                    return x;
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
        }
