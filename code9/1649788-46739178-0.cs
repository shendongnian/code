    public static class HotKeySystem
    {
        public static void ProcessKeyDown(KeyEventArgs args)
        {
            var key = args.Key;
            var action = default(Action);
            lock (mSyncObj) {
                if (!mDownKeys.Contains(key)) {
                    mDownKeys.Add(key);
                    if (mPressActions.TryGetValue(key, out action)) {
                        args.Handled = true;
                    }
                }
            }
            // Invoke outside of the lock.
            action?.Invoke();
        }
        public static void ProcessKeyUp(KeyEventArgs args)
        {
            var key = args.Key;
            var action = default(Action);
            lock (mSyncObj) {
                if (mDownKeys.Remove(key)) {
                    Action action;
                    if (mReleaseActions.TryGetValue(key, out action)) {
                        args.Handled = true;
                    }
                }
            }
            // Invoke outside of the lock.
            action?.Invoke();
        }
        public static void AttachPressAction(KeyCode key, Action action)
        {
            if (action == null) {
                throw new ArgumentNullException(nameof(action));
            }
            lock (mSyncObj) {
                mPressActions.Add(key, action);
            }
        }
        public static bool DetachPressAction(KeyCode key)
        {
            lock (mSyncObj) {
                return mPressActions.Remove(key);
            }
        }
        public static void AttachReleaseAction(KeyCode key, Action action)
        {
            if (action == null) {
                throw new ArgumentNullException(nameof(action));
            }
            lock (mSyncObj) {
                mReleaseActions.Add(key, action);
            }
        }
        public static bool DetachReleaseAction(KeyCode key)
        {
            lock (mSyncObj) {
                return mReleaseActions.Remove(key);
            }
        }
    
        private static readonly object mSyncObj = new object();
        // The keys that are currently down.
        private static readonly HashSet<KeyCode> mDownKeys = new HashSet<KeyCode>();
        // Actions triggered when a key was up, but is now down.
        private static readonly Dictionary<KeyCode, Action> mPressActions = new Dictionary<KeyCode, Action>();
        // Actions triggered when a key was down, but is now up.
        private static readonly Dictionary<KeyCode, Action> mReleaseActions = new Dictionary<KeyCode, Action>();
    }
    
    // When possible, subclass your windows from this to automatically add hotkey support.
    public class HotKeyWindow : Window
    {
        protected override void OnPreviewKeyDown(KeyEventArgs args)
        {
            HotKeySystem.ProcessKeyDown(args);
        }
        protected override void OnPreviewKeyUp(KeyEventArgs args)
        {
            HotKeySystem.ProcessKeyUp(args);
        }
    }
    // When not possible, attach event handlers like this:
    window.PreviewKeyDown += HotKeySystem.ProcessKeyDown;
    window.PreviewKeyUp += HotKeySystem.ProcessKeyUp;
    // Use it like this:
    HotKeySystem.AttachPressAction(KeyCode.F1, () => {
        // F1 hotkey functionality.
    });
