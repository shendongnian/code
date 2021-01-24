    public double AmountCcy1
    {
        get { return _amountCcy1; }
        set
        {
            if (Math.Round(value, 2) != Math.Round(_amountCcy1, 2))
            {
                _amountCcy1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountCcy1"));
            }
        }
    }
    public double AmountCcy2
    {
        get { return _amountCcy2; }
        set
        {
            if (Math.Round(value, 2) != Math.Round(_amountCcy2, 2))
            {
                _amountCcy2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountCcy2"));
            }
        }
    }
