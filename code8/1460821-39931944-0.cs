            if (Count != 0 && cusReader.HasRows && cusReader["Sell"] != DBNull.Value)
            {
                labelInsertedExtra.Visible = true;
                labelInserted.Visible = true;
                labelInsertedExtra.Text = cusReader["Sell"].ToString(); 
            }
            else
            {
                labelInsertedExtra.Visible = false;
                labelInserted.Visible = false;
            }
