    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    namespace FormsDataGridViewBinding
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();            
            }
    
            public BindingList<Person> Persons 
            { 
                get; set; 
            }
    
            private void Form2_Load(object sender, System.EventArgs e)
            {
                dataGridView1.DataSource = Persons; 
            }        
        }
    }
