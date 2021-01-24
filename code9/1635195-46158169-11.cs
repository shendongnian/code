     public class ProgressWindowService : IProgressWindowService
    {
        public void Show(Window owner = null)
        {
            ProgressWindowHelper.Show(owner);
        }
        public void Close()
        {
            ProgressWindowHelper.Close();
        }
        public void SetProgress(double progress, double maxProgress)
        {
            ProgressWindowHelper.SetProgress(progress, maxProgress);
        }
        public void SetIsIndeterminate(bool isIndeterminate)
        {
            ProgressWindowHelper.SetIsIndeterminate(isIndeterminate);
        }
        public void SetState(string state)
        {
            ProgressWindowHelper.SetState(state);
        }
        public void SetIsCancelAllowed(bool isCancelAllowed, Action progressWindowCancel)
        {
            ProgressWindowHelper.SetIsCancelAllowed(isCancelAllowed, progressWindowCancel);
        }
    }
