    [Display(Name = "License Types")]
    public IEnumerable<string> AllLicenseTypes {
        get {
            return Enum.GetNames(typeof(LicenseTypesEnum));
        }
    }
