    public abstract BaseCodes
    {
        protected ReadOnlyDictionary<int, string> CommonCodes = new ReadOnlyDictionary<int, string>
        {
            {0, "Fault1"},
            {513, "Fault2"}
        };
    }
    public class DerivedCodes1 : BaseCodes
    {
        public DerivedCodes1() 
        {
            // Get a writable copy of the common codes
            var codes = CommonCodes.ToDictionary();
            codes.Add(404, "Not Found");
            codes.Add(42, "Life, the Universe, and Everything");
            Codes = new ReadOnlyDictionary<int, string>(codes);            
        }
        public ReadOnlyDictionary<int, string> Codes;
    }
