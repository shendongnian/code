    public void searchenrolee()
    {
        MySqlCommand cmd = connection.CreateCommand();
        MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
        try
        {
            connection.Open();
            string value = "Fullname";
            cmd.CommandText = String.Format(
                        @"Select EEid, CONCAT(Fname,' ', Mname,' ', Lname) AS Fullname, DateRegistered
                        from studenttbl
                        where CONCAT(Fname,' ', Mname,' ', Lname) like @searchKey AND year(DateRegistered) = '" + cbStudYear.selectedValue.ToString() + "' AND Enrollingto = '" + cbSLGrade.selectedValue.ToString() + "' order by EEid desc", value);
            cmd.Parameters.AddWithValue("@searchKey", '%' + tbsearchEnrolee.Text.ToString() + '%');
            MySqlDataAdapter kuhain = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            dgvStudentList.DataSource = ds.Tables[0].DefaultView;
            connection.Close();
        }
        catch
        {
            connection.Close();
        }
    }
    private void tbsearchEnrolee_TextChanged(object sender, EventArgs e)
    {
        searchenrolee();
    }
