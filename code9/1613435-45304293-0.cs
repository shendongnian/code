        protected void gvFeeTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvFeeTable.EditIndex = e.NewEditIndex;
            BindFeeTableGrid(9);
            foreach (Control c in gvFeeTable.Rows[gvFeeTable.EditIndex].Controls)
            {
                if (c.GetType() == typeof(DataControlFieldCell))
                {
                    foreach (Control control in c.Controls)
                    {
                        TextBox myTextBox = control as TextBox;
                        if (myTextBox != null)
                        {
                            myTextBox.Width = 50;
                        }
                    }
                }
            }
        }
