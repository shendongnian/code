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
            NewTabPage?.Invoke("ASD");
        }
    }
