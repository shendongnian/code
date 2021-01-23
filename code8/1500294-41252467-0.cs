    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int? Year {
        get { return _year; }
        set {
            _year = value;
            ModelYear = value.ToString();
        }
    }
