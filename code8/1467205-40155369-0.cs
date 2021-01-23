    public DateTime ShipmentDateTime
    {
    get { return _ShipmentDateTime; }
    set { 
        var dateTimeOffset = DateTimeOffset.Parse(value); //value = "2016/08/03 05:09 +01:00"
     _ShipmentDateTime = dateTimeOffset.UtcDateTime; 
        }
    }
