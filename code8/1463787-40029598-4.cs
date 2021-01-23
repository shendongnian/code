    public class DataItemType<TValue> : DataItem where TValue : struct
    {
        public DataItemType(TValue someParameter, string sNameArg, string sAddressArg, bool nWriteAllowedArg)
            : base(sNameArg, sAddressArg, nWriteAllowedArg)
        {
        }
        //Note that as in the constructor you can use this generic type for the function
        public void SomeFunction(TValue value) { }
        //Or define a new generic type which will be only in the scope of this function
        public void SomeOtherFunction<TValue2>(TValue2 value2) { }
    }
