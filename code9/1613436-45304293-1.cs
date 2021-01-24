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
                        TextBox tb = control as TextBox;
                        
                        if (tb != null)
                        {
                            tb.Width = 50;
                            double dbl;
                            bool isNumeric = double.TryParse(tb.Text, out dbl);
                            if (isNumeric == true)
                            {
                                tb.Text = Convert.ToDecimal(tb.Text).ToString("0.00");
                            }
                        }
                    }
                }
            }
        }
