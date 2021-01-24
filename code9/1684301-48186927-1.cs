    public class DummyViewModelProxy : DummyViewModel
    {
        protected override bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var interceptor = new DummyInterceptor();
            IInvocation invocation = new Invocation(storage, value, propertyName);
            interceptor.Intercept(invocation);
            storage = (T)invocation.Arguments[0];
            return (bool)invocation.ReturnValue;
        }
        ....
    }
