    public override bool IsValid(object value, ValidationContext validationContext)
    {
        var dataHeader = validationContext.ObjectInstance as Data_Header;
        var dueDate = dataHeader.CalculateDueDate;
        bool isValid = false;
        
        if (dueDate.CompareTo(DateTime.Now) < 0 ||
            dueDate.CompareTo(dataHeader.DeliveryDate) < 0)
        {
           isValid = false;
        }
        return isValid;
    }
