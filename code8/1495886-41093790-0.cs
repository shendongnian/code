    class CommonData
    {
        public string CommonStuff { get; set; }
    }
    class GPSData : CommonData
    {
        public string GPSStuff { get; set; }
    }
    class DigitalData : CommonData
    {
        public string DigitalStuff { get; set; }
    }
    class DriverData : CommonData
    {
        public string DriverStuff { get; set; }
    }
    public static class FieldStuff
    {
        public static void TryStuff(int aFieldId)
        {
            CommonData dataField = null;
            switch (aFieldId)
            {
                case (0):
                    dataField = new GPSData();
                    dataField.CommonStuff = "abcd";
                    (dataField as GPSData).GPSStuff = "bcde";
                    break;
                case (1):
                    dataField = new DigitalData();
                    dataField.CommonStuff = "abcd";
                    (dataField as DigitalData).DigitalStuff = "cdef";
                    break;
                case (2):
                    dataField = new DriverData();
                    dataField.CommonStuff = "abcd";
                    (dataField as DriverData).DriverStuff = "defg";
                    break;
                default:
                    break;
            }
        }
    }
