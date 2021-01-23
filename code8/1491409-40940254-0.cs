    protected void GridViewTotal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (_counter == 1)
                {
                    Button btnEdit = e.Row.FindControl("ButtonEdit") as Button;
                    Button btnDelete = e.Row.FindControl("ButtonDelete") as Button;
                    Button btnConfirm = e.Row.FindControl("ButtonConfirmEdit") as Button;
                    Button btnCancel = e.Row.FindControl("ButtonCancelEdit") as Button;
                    btnCancel.Visible = true;
                    btnConfirm.Visible = true;
                    btnDelete.Visible = false;
                    btnEdit.Visible = false;
                }
            }
        }
