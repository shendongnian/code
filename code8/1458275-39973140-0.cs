    public static class UIDispatcher
    {
        private static bool _isTestInstance;
        /// <summary>
        ///      Executes an action on the UI thread. If this method is called from the UI
        ///     thread, the action is executed immendiately. If the method is called from
        ///     another thread, the action will be enqueued on the UI thread's dispatcher
        ///     and executed asynchronously.
        ///     For additional operations on the UI thread, you can get a reference to the
        ///     UI thread's dispatcher thanks to the property GalaSoft.MvvmLight.Threading.DispatcherHelper.UIDispatcher
        /// </summary>
        /// <param name="action">The action that will be executed on the UI thread.</param>
        public static void CheckBeginInvokeOnUI(Action action)
        {
            if (action == null)
            {
                return;
            }
            if ((_isTestInstance) || (ViewModelBase.IsInDesignModeStatic))
            {
                action();
            }
            else
            {
                DispatcherHelper.CheckBeginInvokeOnUI(action);
            }
        }
        /// <summary>
        ///     This method should be called once on the UI thread to ensure that the GalaSoft.MvvmLight.Threading.DispatcherHelper.UIDispatcher
        ///     property is initialized.
        ///     In a Silverlight application, call this method in the Application_Startup
        ///     event handler, after the MainPage is constructed.
        ///     In WPF, call this method on the static App() constructor.
        /// </summary>
        /// <param name="isTestInstance"></param>
        public static void Initialize(bool isTestInstance = false)
        {
            _isTestInstance = isTestInstance;
            if (!_isTestInstance)
                DispatcherHelper.Initialize();
        }
        /// <summary>
        ///    Resets the class by deleting the GalaSoft.MvvmLight.Threading.DispatcherHelper.UIDispatcher
        /// </summary>
        public static void Reset()
        {
            if (!_isTestInstance)
                DispatcherHelper.Reset();
        }
    }
