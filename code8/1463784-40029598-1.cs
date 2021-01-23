    public class DataItem
    {
        public DataItem(string sNameArg, string sAddressArg, bool nWriteAllowedArg) {}
    }
    public class DataItemType<TValue> : DataItem where TValue : struct
    {
        public DataItemType(string sNameArg, string sAddressArg, bool nWriteAllowedArg) 
            : base(sNameArg, sAddressArg, nWriteAllowedArg)
        {
        }
    }
