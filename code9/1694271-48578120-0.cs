     if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnDelete = (Button)gvResult.Row.FindControl("btnDelete");
                CheckBox chkBox = (CheckBox)gvResult.Row.FindControl("chkBox");
                if (chkBox.Checked == true)
                {
                    if (chkBox.Text != "")
                    {
                        int id = Convert.ToInt32(chkBox.Text);
                        //Pass this ID to DB and Delete record.
                        string SQL = string.Format(@"DELETE FROM RF_HANDLING WHERE LOTNUM = '{0}' AND PRICE = '{1}'", LotName, PRICE);
                    }
                }
            }
