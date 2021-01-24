    class ShellViewModel : Conductor<object>
    {
        public void Open_ToolInventory()
        {
            ActivateItem(new TIViewModel());
        }
        public void ViewProblemReport()
        {
            WindowManager wm = new WindowManager();
            VPRViewModel vprvm = new VPRViewModel();
            wm.ShowDialog(vprvm);
        }
    }
