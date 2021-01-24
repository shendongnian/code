    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadFromDatabase();
        }
        public LoadFromDatabase()
        {
            
            BookListBox.Items.Clear(); //Without this you'll get an ever expanding list
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "SELECT * FROM Author";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Author a = new Author();
                            a.Id = reader.GetInt32(0);
                            a.Name = reader.GetString(1);
                            a.Nationality = reader.GetString(2);
                            AuthorListBox.Items.Add(a.Name);
                            Book b = new Book();
                            b.BookId = reader.GetInt32(0);
                            //b.AuthorID = reader.GetInt32(1);
                            b.Title = reader.GetString(2);
                            BookListBox.Items.Add(b.BookId);
                         }
                     }
                 }
             }
         }
        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Author SET AuthorId = '" + this.IdTextBox.Text + "' ," +
                    " Name = '" + this.AuthorNameTextBox.Text + "', Nationality = '" + this.NationalityTextBox.Text +
                    "' WHERE AuthorId = '" + this.IdTextBox.Text + "' ";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Updated the author");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            LoadFromDatabase();
        }
    }
