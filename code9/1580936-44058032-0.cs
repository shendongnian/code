        public int AllowedHorizontalSpace
        {
            get { return this.allowedHorizontalSpace; }
            set
            {
                this.allowedHorizontalSpace = value;
                //                this.OnPropertyChanged(nameof(this.AllowedHorizontalSpace));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllowedHorizontalSpace"));
            }
        }
