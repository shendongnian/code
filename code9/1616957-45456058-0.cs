	public string Department { get; set; }
    public string DepartmentDisplay
    {
        get
        {
            if (Department == "100AB")
                return "Financial";
            if (Department == "200CB")
                return "Administration";
            return "";
        }
    }
