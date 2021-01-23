        public void PinsCollectionChanged()
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomPins)));
            Debug.WriteLine("Updated !!!");
        }
