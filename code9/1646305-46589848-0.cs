    private void DeleteSelectedItemFromListView() {
            var cashierId = listView1.FocusedItem.Text;
            string query = "delete from Tbl_Cashier where Cashier_ID=@id;";
            using (SqlConnection con = new SqlConnection(connectionString1)) {
                try {
                    con.Open();
                    using (SqlTransaction trans = con.BeginTransaction()) {
                        using (SqlCommand com = new SqlCommand(query, con, trans)) {
                            com.Parameters.AddWithValue("id", cashierId);
                            var should_be_one = com.ExecuteNonQuery();
                            if (should_be_one == 1) {
                                trans.Commit();
                            } else {
                                trans.Rollback();
                                throw new Exception("An attempt to delete multiple rows was detected");
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    con.Close();
                }
            }
        }
