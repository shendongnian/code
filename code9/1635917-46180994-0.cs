    public partial class Form1 : Form
    {
        private bool closeCriteriaMet;
        public Form1()
        {
            InitializeComponents();
           
            // subscribe event
            Closing += OnFormClosing;
        }
        // "Closing" event handler
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !closeCriteriaMet; // tell the Form not to close 
        }
    }
