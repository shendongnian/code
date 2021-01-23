    /// <summary>
    /// Represents a wrapper for using task based messageboxes.
    /// </summary>
    public static class AdvancedMessageBox
    {
        /// <summary>
        /// Does show a messagebox inside another task, so it has rather no impact to the main thread.
        /// </summary>
        public static void TaskBasedShow(
            string message,
            string caption,
            MessageBoxButton buttons,
            MessageBoxImage image)
        {
            Task.Run(() =>
            {
                MyResult = MessageBox.Show(message, caption, buttons, image);
            });
        }
        public delegate void OnResult(MessageBoxResult res);
        /// <summary>
        /// Will get triggered, when the user pressed a button on a messagebox (after calling TaskBasedShow).
        /// </summary>
        public static event OnResult OnRes;
        /// <summary>
        /// It will automatically trigger the OnRes subscibers, after setting a value.
        /// </summary>
        private static MessageBoxResult MyResult
        {
            set
            {
                OnRes?.Invoke(value);
            }
        }
    }
