    protected void grdBookDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                BookDetailsBEL.BookId = Convert.ToInt32(grdBookDetails.DataKeys[e.RowIndex].Value);
                BookDetailsBEL.BookName = ((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtEditBookName"))).Text.ToString();
                BookDetailsBEL.Author = ((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtEditAuthor"))).Text.ToString();
                BookDetailsBEL.Publisher = ((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtEditPublisher"))).Text.ToString();
                BookDetailsBEL.Price = Convert.ToDecimal(((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtEditPrice"))).Text.ToString());
                e.Cancel = true;
                grdBookDetails.EditIndex = -1;
                GetBookDetails();
            }
