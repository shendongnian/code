        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler TextChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                if (propertyName == "Text")
                {
					TextChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
