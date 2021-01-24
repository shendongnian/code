    SqlTransaction tr = null;
    try
    {
        string cmdText = @"insert into location(Storage, Shelf, columns, rows) 
                           values(@storage,@shelf,@columns,@rows);
                           select scope_identity()"; 
        using(SqlConnection sqlCon = new SqlConnection(.....))
        using(SqlCommand cmd = new SqlCommand(cmdText, sqlCon))
        {
             sqlCon.Open();
             using( tr = sqlCon.BeginTransaction())
             {
                 cmd.Parameters.Add("@storage", SqlDbType.Int).Value = Convert.ToInt32(txtWarehouse.Text);
                 cmd.Parameters.Add("@shelf", SqlDbType.Int).Value = Convert.ToInt32(txtShelf.Text);
                 cmd.Parameters.Add("@columns", SqlDbType.Int).Value = Convert.ToInt32(txtColumn.Text );
                 cmd.Parameters.Add("@rows", SqlDbType.Int).Value = Convert.ToInt32(txtRow.Text);
                 int newLocation = Convert.ToInt32(cmd.ExecuteScalar());
                 cmdText = @"insert into product(SKU, nimetus, minimum, maximum, quantity,location_ID,category_ID,OrderMail_ID) 
                             values (@sku, @nimetus,@min,@max,@qty,@locid,@catid,@ordid)";
                  cmd = new SqlCommand(cmdText, sqlCon);
                  cmd.Parameters.Add("@sku", SqlDbType.NVarChar).Value = txtSku.Text;
                  .... and so on for the other parameters required
                  cmd.ExecuteNonQuery();
                  tr.Commit();
            }
        }
    }
    catch (Exception er)
    {
        tr.Rollback();
        MessageBox.Show(er.Message);
    }
