    private string _employeeId;
    
    public string EmployeeId
    {
        get
        {
            return this._employeeId
        }
        set
        {
            if (!String.IsNullOrEmpty(value))
            {
                this._employeeId = value;
            }
            else 
            {
                throw new Exception("Employee ID is required");
            }
        }  
    }
