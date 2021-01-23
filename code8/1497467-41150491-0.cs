    public partial class Form1 : Form
    {
        // Initialize private generic list where all customers will be stored at runtime
        private List<Customer> _customers = new List<Customer>();
    
        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            // It might be a good idea to add some validation logic before assigning the input values
            var newCustomer = new Customer();
            newCustomer.Name = this.textBoxName.Text;
            newCustomer.Age = Convert.ToInt32(this.textBoxAge.Text);
            newCustomer.Address1 = this.textBoxAddress1.Text;
            newCustomer.Address2 = this.textBoxAddress2.Text;
            newCustomer.Address3 = this.textBoxAddress3.Text;
    
            _customers.Add(newCustomer);
        }
    }
