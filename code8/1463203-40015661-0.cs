    void FilterDBbtnClick(object sender, EventArgs e)
    {
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(cs);
			
			//string data = "SELECT `Date`, `Process`, `Actual`, `Target` FROM `database` WHERE `Date` BETWEEN '"+this.fromDatePicker.Value+"' AND  '"+this.toDatePicker.Value+"' order by `Date` desc";
			
			//Changed query for getting data from DB according to the date 
            string data = "SELECT CreatedDate, Process, Actual, Target FROM database WHERE Convert(varchar(10),CreatedDate,120) BETWEEN '"+this.fromDatePicker.Value.ToString("yyyy-MM-dd")+"' AND  '"+this.toDatePicker.Value.ToString("yyyy-MM-dd")+"' order by CreatedDate desc";
            MySqlCommand cmd = new MySqlCommand(data, conn);
            cmd.Connection.Open();
            try
            {
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmd;            
            DataSet dt = new DataSet();
            sda.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            mondeDataTable.DataSource = dt.Tables[0];
            sda.Update(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cmd.Connection.Close();
    }
