    namespace Listviews
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            // Not needed
            //ListViewItem lvi = new ListViewItem();
    
            private void btnAdd_Click(object sender, EventArgs e)
            {
                string time = DateTime.Now.ToString("HH:mm");
                // Just add the time directly as a string
                listView1.Items.Add(time);
            }
        }
    }
