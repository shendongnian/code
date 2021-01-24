    public class KeyboardHandler : IDisposable
        {
            private readonly int _modKey;
            private const int WmHotkey = 0x0312;
            private readonly WindowInteropHelper _host;
    
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
    
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    
    
            private readonly ISubject<Unit> _hotKeyHandleSubject = new Subject<Unit>();
            public IObservable<Unit> WhenHotKeyHandled { get { return _hotKeyHandleSubject.AsObservable(); } }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="mainWindow">the handle to the main window</param>
            /// <param name="vkKey">the virtual key you need to press -> https://msdn.microsoft.com/en-us/library/ms927178.aspx </param>
            /// <param name="modKey">the modifier key you need to press (2 is CTRL by Default) -> https://msdn.microsoft.com/it-it/library/windows/desktop/ms646279(v=vs.85).aspx </param>
            public KeyboardHandler(Window mainWindow, int vkKey, int modKey = 2)
            {
                _modKey = modKey;
                _host = new WindowInteropHelper(mainWindow);
    
                SetupHotKey(_host.Handle, vkKey);
                ComponentDispatcher.ThreadPreprocessMessage += ComponentDispatcher_ThreadPreprocessMessage;
            }
    
            private void ComponentDispatcher_ThreadPreprocessMessage(ref MSG msg, ref bool handled)
            {
                if (msg.message == WmHotkey)
                {
                    _hotKeyHandleSubject.OnNext(Unit.Default);
                }
            }
    
            private void SetupHotKey(IntPtr handle, int vkKey)
            {
                RegisterHotKey(handle, GetType().GetHashCode(), _modKey, vkKey);
            }
    
            public void Dispose()
            {
                ComponentDispatcher.ThreadPreprocessMessage -= ComponentDispatcher_ThreadPreprocessMessage;
                UnregisterHotKey(_host.Handle, GetType().GetHashCode());
            }
        }
