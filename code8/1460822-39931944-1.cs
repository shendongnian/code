          while (cusReader.Read())
          {
            if (Count != 0 && cusReader["Sell"] != DBNull.Value)
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
             
            break;
          }
