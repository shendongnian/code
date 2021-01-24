    private string password;
    [DataType(DataType.Password)]
    [Display(Name = "Update Password")]
    public string Password 
    { 
        get
        {
            return password;
        }
        set
        {
            if (value != null)
            {
                password = value;
            }
        }
    }
