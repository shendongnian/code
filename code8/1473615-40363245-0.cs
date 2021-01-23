    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    public class WindowsDialogBoxView : WinWindow
    {
        public WindowsDialogBoxView()
        {
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32770";
        }
        public WinEdit FilenameEdit
        {
            get
            {
                this.filenameEdit = new WinEdit(this);
                this.filenameEdit.SearchProperties[WinEdit.PropertyNames.Name] = "File name:";
                return this.filenameEdit;
            }
        }
        private WinEdit filenameEdit;
