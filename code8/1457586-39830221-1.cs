    protected void GridViewLehrling_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (GridViewLehrling.Rows.Count > 0)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        DropDownList DropDownListDienstleistungBackEnd = (DropDownList)GridViewLehrling.Rows[GridViewLehrling.SelectedIndex].FindControl("DropDownListDienstleistung");
                        HiddenField HiddenFieldGutscheinartIDBackEnd = (HiddenField)GridViewLehrling.Rows[GridViewLehrling.EditIndex].FindControl("HiddenFieldGutscheinartID");
                    }
                }
            }
