    public class MyException : Exception
    {
        private static string BaseExceptionMessage(int ErrCode, Dictionary<string,string> Params)
        {
            return Params.Aggregate(ErrorList[ErrCode].MessageExternal, (i, a) => i.Replace(a.Key, a.Value));
        }
        public MyException(int ErrCode, Dictionary<string, string> Params) : base(BaseExceptionMessage(ErrCode, Params))
        {
            ErrorDetail = ErrorList[ErrCode];
    
            string msg_internal = "";
            string msg_external = "";
    
            foreach (var item in Params)
            {
                msg_internal = ErrorDetail.MessageInternal.Replace(item.Key, item.Value);
                msg_external = ErrorDetail.MessageExternal.Replace(item.Key, item.Value);
            }
        }
    
    }
