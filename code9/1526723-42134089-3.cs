        private int? _quantity;
        public int? Quantity
        {
            get { return _quantity; }
            set
            {
                if (!value.HasValue || value <= 0)
                {
                    SetError(nameof(Quantity), Resources.Properties.Resources.OrderQuantityMustBePositiveErrorMessage);
                }
                else
                {
                    ClearErrors(nameof(Quantity));
                    this.RaiseAndSetIfChanged(ref _quantity, value);
                }
            }
        }
