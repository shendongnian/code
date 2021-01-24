    public sealed partial class Plant : IEukaryote
    {
        public System.Collections.Generic.IEnumerable<ICell> Cells { get { return (_valuesDict["Cells"] as System.Collections.IEnumerable).Cast<ICell>(); } }
        public string GenericName { get { return _valuesDict["GenericName"] as string; } }
        public string FieldIWantSerialized;
        public int SomethingIDoNotWantSerialized { get { return 99999; } }
        // Remainder as before.
