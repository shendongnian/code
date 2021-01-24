    public string first_name { get; set; }
    public string last_name { get; set; }
    [Display(Name="Name")]
    public string FullName { get { return first_name + " " + last_name; }
 
