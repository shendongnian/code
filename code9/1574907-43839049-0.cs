        private void SaveMulti(object sender, RoutedEventArgs e)
        {
            string CStr = Manifesting.Properties.Settings.Default.PSIOpsSurfaceCS;
            string Query = "INSERT INTO TestLoop (Record) Values (@Record)";
            string Record = StackBoxes.Children.OfType<TextBox>().ToString();
            using(var conn = new SqlConnection(CStr))
            {
                foreach (TextBox TestTB in StackBoxes.Children.OfType<TextBox>())
                {
                    using(var cmd = new SqlCommand(Query, conn))
                    {
                        try
                        {
                            cmd = conn.CreateCommand();
                            cmd.Parameters.AddWithValue("@Record", TestTB.Text);
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }
