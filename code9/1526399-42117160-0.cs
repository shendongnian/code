    using System;
    using System.Windows.Forms;
    using System.Data.Entity;
    namespace WindowsFormsApplication
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            SampleDBEntities db;
            private void Form1_Load(object sender, EventArgs e)
            {
                SampleDBEntities db = new SampleDBEntities();
                db.Products.Load();
                this.productBindingSource.DataSource = db.Products.Local.ToBindingList();
            }
            private void SaveButton_Click(object sender, EventArgs e)
            {
                db.SaveChanges();
            }
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                db.Dispose();
            }
        }
    }
    
