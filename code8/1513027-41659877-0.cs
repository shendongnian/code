    public class ReturnValues
    {
        public object ReturnValue;
        public ReturnValueType Type;
    }
    enum ReturnValueType
    {
        typeOfString,
        typeOfImage,
        typeofInt
    }
    public static ReturnValues queeString (string str, string b)
    {
        //.....
        return new ReturnValues{ ReturnValue="Test",  Type=ReturnValueType.typeOfString };
    } 
