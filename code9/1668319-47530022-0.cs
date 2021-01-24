    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                List<Customer> lst = new List<Customer>() { new Customer() { ID = 1, Name = "XYZ" }, new Customer() { ID = 1, Name = "XYZ" } };
    
                dataGridView1.DataSource = lst;
                
                DataGridViewRowCollection c =  dataGridView1.Rows;
                DataGridViewRow val = dataGridView1.Rows[0];
                Console.WriteLine(val.Cells[0].Value);
            }
    
            private class Customer
            {
                public int ID { get; set; }
                public string Name { get; set; }
            }
        }
