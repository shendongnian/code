        public string SelectedName
        {
            get { return _namesList[1]; }
            set
            {
                if (value == _namesList[1]) return;
                _namesList[1] = value;
                NotifyPropertyChanged("SelectedName");
            }
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            var str = _namesList[0];
            _namesList[0] = _namesList[1];
            SelectedName = str;            
            IsEnabled = false;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            var str = _namesList[2];
            _namesList[2] = _namesList[1];
            SelectedName = str;            
            IsEnabled = false;
        }
