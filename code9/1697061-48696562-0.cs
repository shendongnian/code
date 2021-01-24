     public partial class Form1 : Form
     {
        public List<Customer> Customers { get; set; } = new List<Customer>
        {
            new Customer
            {
                Name = "John",
                Phone = "123"
            },
            new Customer
            {
                Name = "Mary",
                Phone = "123"
            },
            new Customer
            {
                Name = "Peter",
                Phone = "555"
            },
            new Customer
            {
                Name = "George",
                Phone = "222"
            },
            new Customer
            {
                Name = "Christine",
                Phone = "555"
            }
        };
        public Form1()
        {
            InitializeComponent();
            CustomersPhone_ComBx.DataSource = Customers.Select(Customer => Customer.Phone).ToList();
            CustomersName_ComBx.DataSource = Customers.Select(Customer => Customer.Name).ToList();
        }
        private void CustomersPhone_ComBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPhone = (string) CustomersPhone_ComBx.SelectedItem;
            if (!String.IsNullOrEmpty(selectedPhone))
                CustomersName_ComBx.DataSource = Customers.Where(Customer => Customer.Phone == selectedPhone).Select(Customer => Customer.Name).ToList();
            else
                CustomersName_ComBx.DataSource = Customers.Select(Customer => Customer.Name).ToList();
        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
