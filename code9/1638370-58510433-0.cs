    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(ICSharpCom))]
    [ComSourceInterfaces(typeof(ICSharpComEventHandler))]
    [Guid("XXXXXX-xxxx-xxx-xxx-XXXXX")]
    public class CSharpCom : ICSharpCom
    {
        [ComVisible(false)]
        public delegate void WorkCompleted(string result);
        public event WorkCompleted OnWorkCompleted;
        public int DoWork(string input)
        {
           Task t = ....
           // do some hard work aync by usin
           OnWorkCompleted?.Invoke(t.Result);
        } 
    }
    [ComVisible(true)]
    [Guid("XXXXXX-xxxx-yyy-xxx-XXXXX")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ICSharpComEventHandler 
    {
        [DispId(1)]
        void OnWorkCompleted(string result);
    }
