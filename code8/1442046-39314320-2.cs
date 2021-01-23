    private void btn_delete_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewCell oneCell in datagrid_booktitles.SelectedCells)
        {
            if (oneCell.Selected == false) continue;
            
            datagrid_booktitles.Rows.RemoveAt(oneCell.RowIndex);
            string query = 
                "DELETE FROM `sarasavi_library`.`book_title` WHERE `book_number`='book_number'"
           
            using(var conn = new MySqlConnection("yourConnectionString"))
            {
                using(var command = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
