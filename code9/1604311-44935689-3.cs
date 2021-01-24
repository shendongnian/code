    textbox2.DataBinding.Clear(); //clear the databinding so it can be added for the new data found.
    
    using(SqlConnection conn = new SqlConnection("Your connection string here")
    using (SqlDataAdapter da = new SqlDataAdapter("SELECT * from stackTable where itemCodu=@Cod")
    {
         da.SelectCommand.Parameters.Add("@Cod", sqlDbType.VarChar).Value = textBox1.Text; //see comment below for this change
         da.fill(dt);
         if (dt.Rows.Count == 0)
         {
             //display not found message
         }
         else
         {
             //bind to textbox (described above)
         }
     }
