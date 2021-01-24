    public partial class MyWindowControl : UserControl
    {
        // output omitted for brevity
        public void Save()
        {
            // Do the call towards view-model or run the code
            (this.DataContext as MyViewModel)?.SaveCmd.Execute(null);
        }
    }
