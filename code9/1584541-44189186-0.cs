    public void ShowData(int bookId)
    {
        // Select returns an array of DataRows that match the condition
        // in your case probably you have zero or one row returned
        DataRow[] rows = books.Select("BookID = " + bookID);
        if(rows.Length > 0)
        {
            tbID.Text = rows[0][0].ToString();
            comboBoxTitle.Text = rows[0][1].ToString();
            tbPageNumber.Text = rows[0][2].ToString();
            comboBoxBookType.Text = rows[0][3].ToString();
            tbComment.Text = rows[0][4].ToString();
            
            // Consider also that if you delete the found row 
            // probably you want to keep in synch the in memory datatable
            rows[0].Delete();
            books.AcceptChanges();
            
        }
    }
