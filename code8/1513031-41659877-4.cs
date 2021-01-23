    public class ReturnValues
    {
        public object ReturnValue;
        public ReturnValueType RetType;
    }
    enum ReturnValueType
    {
        typeOfString,
        typeOfImage,
        typeofInt
    }
    public static ReturnValues queeString (object[] args)
    {
        //.....
        return new ReturnValues{ ReturnValue="Test",  RetType=ReturnValueType.typeOfString };
    } 
