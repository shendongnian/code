    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    namespace FormsDataGridViewBinding
    {
        public partial class Form1 : Form
        {
            BindingList<Person> personList = new BindingList<Person>();
    
            public Form1()
            {
                personList.Add(new Person("number1", "name1", "address1"));
                personList.Add(new Person("number2", "name2", "address2"));
    
                InitializeComponent();
                dataGridView1.DataSource = personList; 
            }
    
            private void button1_Click(object sender, System.EventArgs e)
            {
                using (var form2 = new Form2())
                {
                    form2.Persons = personList;
                    form2.ShowDialog();                
                }
            }
        }
    }
