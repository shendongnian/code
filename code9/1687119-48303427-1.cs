    public override System.Windows.Controls.ValidationResult Validate(object value, 
        System.Globalization.CultureInfo cultureInfo)
    {
        int myInt;
        if (!int.TryParse(System.Convert.ToString(value), out myInt))
            return new ValidationResult(false, "Illegal characters");
    
        if (myInt < 0 || myInt > 20)
        {
            return new ValidationResult(false, "Please enter a number in the range: 0 - 20");
        }
        else
        {
            return new ValidationResult(true, null);
        }
    }
