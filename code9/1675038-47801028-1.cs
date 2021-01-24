    public double? PartQuantity 
    {
        get
        {
            var value = MaintenanceRequestPart;
            return value == null ? null : value.ReportedQuantity;
        }
    }
