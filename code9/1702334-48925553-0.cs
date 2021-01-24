    public string NIF
    {
        get { return nif; }
        set { if (IsDigitsOnly(value) && CorrectFormat(value))
                nif = value;
        }
    }
