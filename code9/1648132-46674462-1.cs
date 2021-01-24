    class ShellViewModel : Conductor<object>
    {
        TIViewModel tivm = new TIViewModel();
        VPRViewModel vprvm = new VPRViewModel();
        public void OpenToolInventory()
        {
            ActivateItem(tivm);
        }
        public void ViewProblemReport()
        {
            WindowManager wm = new WindowManager();
            wm.ShowDialog(vprvm);
            tivm.PopulateToolInventory();
        }
    }
