    private void addButton_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    NpgsqlConnection con = new NpgsqlConnection("Server=00.0.0.00;Port=1111;Database=TEST_DB;User Id=postgres;Password=****;");
                    con.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into Product(productprice,productqty)values('"+ prodprice.Text.ToString() + "','" + prodqty.Text.ToString() + "')", con);
                    NpgsqlCommand cmd2 = new NpgsqlCommand("update Product set total=productprice*productqty", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    errorMessage.Text = "Item Added Successfully";
                    prodprice.Text = prodqty.Text = "";
                    NpgsqlCommand cmd1 = new NpgsqlCommand("select *from Product", con);
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd1);
                    DataTable dt = new DataTable("Product");
                    adapter.Fill(dt);
                    dataGrid1.ItemsSource = dt.DefaultView;
                }
                catch (NpgsqlException)
                {
                    errorMessage.Text ="Enter Valid Data" ;
                }
            }
