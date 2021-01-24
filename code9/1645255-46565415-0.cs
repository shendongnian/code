    public partial class TaskPaneUploadWizard : UserControl
    {
        //{---}
        CustomTaskPane _HostPane;
        public CustomTaskPane HostPane
        {
             get => _HostPane;
             set
             {
                 if(_HostPane == value)
                     return;
                 _HostPane?.VisibleChanged -= TaskPaneUploadWizard_VisibleChanged;
                 _HostPane = value;
                 _HostPane?.VisibleChanged += TaskPaneUploadWizard_VisibleChanged;
             }
        }
        //{---}
        private void TaskPaneUploadWizard_VisibleChanged(object sender, EventArgs e)
        {
            // Some code
        }
        //{---}
