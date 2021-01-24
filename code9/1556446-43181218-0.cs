    public string Error
    {
        get { return this[null]; }
    }
    public string this[string columnName]
    {
        get
        {                    
            if (columnName == null || columnName == "UnitCode") {
                if (String.IsNullOrEmpty(UnitCode)) {
                    return "Unit Code cannot be empty";
                }
            }
            if (columnName == null || columnName == "UnitName") {
                if (string.IsNullOrEmpty(UnitName)) {
                    return "Unit Name cannot be Empty";
                }
            }
            return null;
        }
    }
