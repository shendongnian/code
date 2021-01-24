    public DoubleValueWithUnit(object obj, Unit unit)
    {
        Unit = unit;
        try
        {
           Value = Convert.ToDouble( obj );
        }
        catch( Exception )
        {
           throw new ArgumentException("Cannot convert to double", nameof(obj) );
        }        
    }
