    // do not forget to mark Form2_Load method as async 
    private async void Form2_Load(object sender, EventArgs e) {
      // Do not share the connection - create it and dispose for each call 
      using (SqlConnection con = new SqlConnection(...)) {
        await con.OpenAsync();
    
        string sql = 
          @"SELECT * 
              FROM Customer_Order_Details 
             WHERE Order_Number = @OrderNumber 
               AND Date_Time = @DateTime";
    
        // do not share command/query as well 
        using (SqlCommand q = new SqlCommand(sql, con)) {
          q.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Order_Number;
          q.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = Date_Time;
    
          dataGridView1.Rows.Clear();
          dataGridView2.Rows[0].Cells[1].Value = 0;
    
          Sum = 0;
     
          // We actually don't want any sql adapter: 
          // all we have to do is to fetach data from cursor and append it to grids
          using (var reader = await q.ExecuteReaderAsync()) {
            while (reader.Read()) {
              dataGridView1.Rows.Add(reader[2], reader[3], reader[4]);
              Sum += Convert.ToDouble(reader[4]);  
            }
          } 
        }  
      }
    }
