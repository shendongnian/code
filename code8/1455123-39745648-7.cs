        public class NewDelegates
        {
            public Action VoidDelegate { get; set; }
            public Action<int> VoidDelegateWithIntParameter { get; set; }
            public Func<int> NonVoidDelegate { get; set; }
            public Func<int, int> NonVoidDelegateWithParameter { get; set; }
            public NewDelegates(Action _voidDelegate,
                                Action<int> _voidDelegateWithParameter,
                                Func<int> _nonVoidDelegate,
                                Func<int, int> _nonVoidDelegateWithParameter)
            {
                VoidDelegate = _voidDelegate;
                VoidDelegateWithIntParameter = voidDelegateWithParameter;
                NonVoidDelegate = nonVoidDelegate;
                NonVoidDelegateWithParameter = nonVoidDelegateWithParameter;
            }
            public void InvokeVoid()
            {
                VoidDelegate();
            }
            public void InvokeVoidWithParams(int arg)
            {
                VoidDelegateWithIntParameter(arg);
            }
            public int InvokeNonVoid()
            {
                return NonVoidDelegate();
            }
            public int InvokeNonVoidDelegateWithParameter(int arg)
            {
                return NonVoidDelegateWithParameter(arg);
            }
        }
