    private async Task<Customers> GetAllCustomersAsync()
    {
       var customers = new DataTable();
       using (var con = new MySqlConnection(""))
       using (var cmd = new MySqlCommand("SELECT * FROM Customers", con))
       {
           await con.OpenAsync();
           cmd.CommandType = CommandType.Text;
           var sda = new MySqlDataAdapter(cmd);
           await sda.FillAsync(customers);
       }
       return customers;
    }
