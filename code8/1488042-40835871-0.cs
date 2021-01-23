    string sqlQuery = "UPDATE EmpJobs SET Hours_Spent=@Hours_Spent, Job_Date =@Job_Date" + 
                      " WHERE Client_Name=@Client_Name AND Emp_Name=@Emp_Name"
  
    sqlCommand.CommandText = sqlQuery;
    sqlCommand.Parameters.Add("@Hours_Spent",SqlDbType.Int).Value = comboBox3.SelectedItem;
    sqlCommand.Parameters.Add("@Job_Date",SqlDbType.DateTime).Value = Convert.ToDateTime(dateTimePicker1.Text);
    sqlCommand.Parameters.Add("@Client_Name",SqlDbType.Varchar).Value = comboBox1.SelectedItem;
    sqlCommand.Parameters.Add("@Emp_Name",SqlDbType.Varchar).Value = comboBox2.SelectedItem;
    sqlCommand.ExecuteNonQuery();
