    public class IdDetails
    {
        public string transactionDate { get; set; }
        public string upnName { get; set; }
        public string movementTrade { get; set; }
        public string baseCurve { get; set; }
        public string cTolerance { get; set; }
        private static string SafeString(object s)
        {
            return s == null ? string.Empty : s.ToString();
        }
        public override string ToString()
        {
            PropertyInfo[] properties = typeof(IdDetails).GetProperties();
            return string.Join(",", properties.Select(prop => SafeString(prop.GetValue(this, null))).ToArray());
        }
        //17 more declarations below
    }
