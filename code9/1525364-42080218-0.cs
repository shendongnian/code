    public class IdDetails
    {
        public string transactionDate { get; set; }
        public string upnName { get; set; }
        public string movementTrade { get; set; }
        public string baseCurve { get; set; }
        public string cTolerance { get; set; }
        public override string ToString()
        {
            PropertyInfo[] properties = typeof(IdDetails).GetProperties();
            return string.Join(",", properties.Select(prop => prop.GetValue(this, null)));
        }
        //17 more declarations below
    }
