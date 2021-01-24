    public static class ProgressWindowHelper
    {
        public static void Show(Window owner = null)
        {
            ProgressWindowControl.ShowProgressWindow(owner);
        }
        public static void Close()
        {
            ProgressWindowControl.CloseProgressWindow();
        }
        public static void SetProgress(double progress, double maxProgress)
        {
            ProgressWindowControl.SetProgress(progress, maxProgress);
        }
        public static void SetIsIndeterminate(bool isIndeterminate)
        {
            ProgressWindowControl.SetIsIndeterminate(isIndeterminate);
        }
        public static void SetState(string state)
        {
            ProgressWindowControl.SetState(state);
        }
        public static void SetIsCancelAllowed(bool isCancelAllowed, Action progressWindowCancel)
        {
            ProgressWindowControl.SetIsCancelAllowed(isCancelAllowed, progressWindowCancel);
        }
    }
