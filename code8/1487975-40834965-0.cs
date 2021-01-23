    using System;
    
    namespace DebuggerHelperDLL
    {
        public static class DebuggerHelper
        {
            public static void AddHandler(EventHandler<Debugger.DebugMessageArgs> eventHandler)
            {
                Debugger.Instance.DebugMessageEvent += eventHandler;
            }
        }
    }
