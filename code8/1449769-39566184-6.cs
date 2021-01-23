    public class OperationResult
    {
        /// <summary>
        /// Operation fail code
        /// </summary>
        public static string FAIL = "0";
        /// <summary>
        /// Operation success code
        /// </summary>
        public static string SUCCESS = "1";
        /// <summary>
        /// 1 : Success
        /// 0 : Fail 
        /// Maybe you can use Enum to set ResultCode.
        /// </summary>        
        public string ResultCode { get; set; }
         
        /// <summary>
        /// Exception message
        /// </summary>         
        public string ResultMessage { get; set; }
        
    }
