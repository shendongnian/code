        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.CssClass = "headerCheckBox";
                    checkBox.ID = "headerCheckBox_" + i;
                    e.Row.Cells[i].Controls.Add(checkBox);
                }
            }
        }
