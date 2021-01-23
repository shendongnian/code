        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if the bound data is a generic list, cast back to an individual listitem
                Book book = e.Row.DataItem as Book;
                if (book.id > 3)
                {
                    //add an attribute to the row
                    e.Row.Attributes.Add("style", "background-color: red");
                    //or hide the entire row
                    e.Row.Visible = false;
                }
                //if the bound data is a datatable or sql source, cast back as datarowview
                DataRowView row = e.Row.DataItem as DataRowView;
                if (Convert.ToInt32(row["id"]) > 4)
                {
                    //add an attribute to a cell in the row
                    e.Row.Cells[1].Attributes.Add("style", "background-color: red");
                    //or replace the contents of the cell
                    e.Row.Cells[1].Text = "SOLD OUT";
                }
            }
        }
