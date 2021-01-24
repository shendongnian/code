    private List<decimal> values = new List<decimal>();
    
    private decimal _VValue
    public decimal VValue
    {
        get
        {
            return _VValue;
        }
        set
        {
            values.Add(value);
            _VValue = value;              
            v.Text = _VValue.ToString();                
        }
    }
