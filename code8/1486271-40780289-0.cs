    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var rtn = new ValidationResult();
        if (value==null)
            rtn  = ValidationResult(Admin.ResourceManager.GetString(ErrorMessageResourceName));
        if (!value.GetType().Equals(typeof(string)))
            rtn =  ValidationResult(Admin.ResourceManager.GetString(ErrorMessageResourceName));
        var text = value.ToString();
        if (!Regex.IsMatch(text, "^[-+]?[0-9]{1,2}.?[0-9]{0,6}?,[-+]?[0-9]{1,3}.?[0-9]{0,6}?$"))
            rtn  = ValidationResult(Admin.ResourceManager.GetString(ErrorMessageResourceName));
        var cordinations = text.Split(',');
        if (cordinations.Length != 2)
            rtn  = ValidationResult(Admin.ResourceManager.GetString(ErrorMessageResourceName));
        decimal latitude = 0;
        decimal longitude = 0;
        if (!decimal.TryParse(cordinations[0].Replace(" ", string.Empty), out latitude) || 
            !decimal.TryParse(cordinations[1].Replace(" ", string.Empty), out longitude))
            rtn  = ValidationResult(Admin.ResourceManager.GetString(ErrorMessageResourceName));
        if (!(latitude >= -90 && latitude <= 90) || !(longitude >= -180 && longitude <= 180))
            rtn  =  ValidationResult(Admin.ResourceManager.GetString(ErrorMessageResourceName)); .
        if(rtn.HasNoError) rtn = ValidationResult.Success; // or something of the like
        return rtn;
    }
