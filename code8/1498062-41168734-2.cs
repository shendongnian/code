    public class ListForm: Form
    {
        public delegate void OnNewTabPage(string key);
        public event OnNewTabPage NewTabPage;
        
        public ListForm()
        {
           .....
        }
        
        private void createButton_Click(object sender, EventArgs e)
        {
            // Here we pass to the subscriber of the event just a string as 
            // the delegate requires, but, of course, you could change this 
            // to whatever data you wish to pass to the mainwindow 
            // Event a reference to an instance of a class with many fields...
            NewTabPage?.Invoke("ASD");
        }
    }
