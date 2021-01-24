    public sealed partial class MainPage : Page
    { 
       ...
        private void btngetdata_Click(object sender, RoutedEventArgs e)
        {
            ListCustomer.ItemsSource = SQLiteHelp.getValues();
        }
    }
    public class SQLiteHelp
    {
        private static string DbName = "Sun.db";       
        public static ObservableCollection<Customer> getValues()
        {
            ObservableCollection<Customer> list = new ObservableCollection<Customer>();
            using (var connection = new SQLiteConnection(DbName))
            {
                using (var statement = connection.Prepare(@"SELECT * FROM CUSTOMER;"))
                {
                    while (statement.Step() == SQLiteResult.ROW)
                    {
                        list.Add(new Customer()
                        {
                            Id = Convert.ToInt32(statement[0]),
                            Name = (string)statement[1],
                            City = (string)statement[2],
                            Contact = statement[3].ToString()
                        });
                        Debug.WriteLine(statement[0] + " ---" + statement[1] + " ---" + statement[2] + statement[3]);
                    }
                }
            }
            return list;
        }
      
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
    }
