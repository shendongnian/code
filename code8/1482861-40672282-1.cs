    public class Blah
    {
        public Int32 Id32 { get; set; }
        public Int64 Id64 { get; set; }
    }
    private void DoTest()
    {
        var blah = new Blah
        {
            Id32 = 1,
            Id64 = 1
        };
        object idInt32 = blah.GetType().GetProperty("Id32").GetValue(blah, null);
        object idInt64 = blah.GetType().GetProperty("Id64").GetValue(blah, null);
        object selectedValue = 1; // default type is Int32
        bool areTheSameInt = idInt32.Equals(selectedValue); // true
        bool areTheSameLong = idInt64.Equals(selectedValue); // false
    }
