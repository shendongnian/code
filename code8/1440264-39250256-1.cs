     private void searchTextBoxNaziv_TextChanged(object sender, EventArgs e)
        {
            String selectedColumn = filterSearchCombo.Text;
            String sql = "";
            if (searchTextBoxNaziv.Text.length > 0)
            {
                SqlCommand com = conn.CreateCommand();
                com.Parameters.AddWithValue("@search", searchTextBoxNaziv.Text.ToLower());
                switch (selectedColumn)
                {
                    case "ID":
                        com.Parameters.AddWithValue("@searchItem", "ID");
                        break;
                    case "Name":
                        com.Parameters.AddWithValue("@searchItem", "Name");
                        break;
                    case "Descr":
                        com.Parameters.AddWithValue("@searchItem", "Desc");
                        break;
                    case "Created":
                        com.Parameters.AddWithValue("@searchItem", whateverCreatedIs);
                        break;
                }
                com.CommandText = "select * from grupe_artikala where lcase(@searchItem) like %@search%";
                //execute SELECT
            }
        }
