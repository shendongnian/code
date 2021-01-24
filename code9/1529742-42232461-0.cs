    public IList<SelectListItem> AvailableCountries { get; set; }
    public string CompanyCountry { get; set; } = string.Empty;
	public IList<SelectListItem> AvailableStates { get; set; }
	[StringLength(200, ErrorMessage = "State/Region has a maximum length of 200 characters")]
	public string CompanyRegion { get; set; } = string.Empty;
	
