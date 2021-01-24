    public class MyBase {
        public int ErrorCode { get; set; }
        public string ErrorMessage  { get; set; }
    
        public MyBase ()
        {
            ErrorCode = 0;
            ErrorMessage = null; // or "";
        }
    }
