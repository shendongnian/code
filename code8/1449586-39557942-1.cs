      try
    {
        conn.Open();
        string sql = "Insert into tbl_books (NameOfBook,Author,Publisher,YearPublished,Category,ISBN) values (@book,@author,@publisher,@year,@category,@isbn)";
        MySqlCommand sda = new MySqlCommand(sql,conn);
        sda.Parameters.AddWithValue("@book", txtbook.Text);
        sda.Parameters.AddWithValue("@author", txtauthor.Text);
        sda.Parameters.AddWithValue("@publisher", txtpublisher.Text);
        sda.Parameters.AddWithValue("@year", txtyear.Text);
        sda.Parameters.AddWithValue("@category", cmbcategory.Text);
        sda.Parameters.AddWithValue("@isbn", txtisbn.Text);
        sda.ExecuteNonQuery();
        conn.Close();
        MessageBox.Show("Item has been added");
        showlv("Select * from tbl_books", lvbooks);  
    }
