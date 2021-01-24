    public class Class2
    {
        public static void DoStuff()
        {
            var dialogResult = default(WindowVm).GetReturnType().DialogWithResult<WindowVm>();
        }
    }
    public class MyReturnType { }
    public class DialogResultBase<T> : IDialogWithResult<T> { }
    public interface IDialogWithResult<TSomeReturnType> { }
    
    public class WindowVm : DialogResultBase<MyReturnType> { }
    public class DialogResultHelper<TSomeReturnType>
    {
        public IDialogWithResult<TSomeReturnType> DialogWithResult<TViewModel>() where TViewModel : DialogResultBase<TSomeReturnType>, new()
        {
            return new TViewModel();
        }
    }
    public static class Extensions
    {
        public static DialogResultHelper<T> GetReturnType<T>(this DialogResultBase<T> dialogResultBase)
        {
            return new DialogResultHelper<T>();
        }
    }
