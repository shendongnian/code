    [DebuggerTypeProxy(typeof(BDebugView))]
    public class B : A
    {
        private class BDebugView
        {
            private B _actualObject;
            public string prop4 { get { return _actualObject.prop4; } }
            
            public BDebugView(B actualObject)
            {
                this._actualObject = actualObject;
            }
        }
    }
