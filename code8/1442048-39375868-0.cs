    foreach (DataGridViewCell oneCell in datagrid_booktitles.SelectedCells)
    {
       if (oneCell.Selected == false) continue;
       string i = datagrid_booktitles.SelectedRows[0].Cells[1].Value.ToString();
       datagrid_booktitles.Rows.RemoveAt(oneCell.RowIndex);
       string query = "DELETE FROM `sarasavi_library`.`book_title` WHERE `book_number`='" + i +"'";
       using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ToString()))
       {
          using (var cmd = new MySqlCommand(query, conn))
          {
             conn.Open();
             cmd.ExecuteNonQuery();
          }
        }
      }
