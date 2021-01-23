    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.Entity;
    namespace Gui_mockups
    {
        public partial class Form1 : Form
    {
        Lab_Assistant_backendEntities Database;
        DbSet data;
       
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Database = new Lab_Assistant_backendEntities();
            data = Database.Sample_Register;
            data.Load();
            sample_RegisterBindingSource.DataSource = data.Local;
        }
        private void sample_RegisterBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Database.SaveChanges();
        }
    }
