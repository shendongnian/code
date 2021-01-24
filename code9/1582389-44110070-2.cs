    public static class TupleExtensions
    {
        public static bool HasValue(this Tuple<string, string> tuple)
        {
            return !string.IsNullOrEmpty(tuple?.Item1) && !string.IsNullOrEmpty(tuple?.Item2);
        }
    }
    var UHRSCredentals = Tuple.Create(UserNameLine.Split('\t')[1], PasswordLine.Split('\t')[1]);
    bool hasValue = UHRSCredentals.HasValue(); // True!
