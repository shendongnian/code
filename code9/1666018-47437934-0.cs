    public partial class dlgDetailsObj : Form
    {
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            UpdateListFromDatabase();
        }
        private static void UpdateListFromDatabase()
        {
             var thread = new Thread(() =>
                 {
                     //code that should run separately from the UI
                 });
             thread.Start();
        }       
    }
