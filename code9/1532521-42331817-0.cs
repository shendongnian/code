    public string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyDataBase.mdf;Integrated Security=True";
    try
    { 
     SaveFileDialog sd = new SaveFileDialog();
     sd.Filter = "SQL Server database backup files|*.bak";
     sd.Title = "Create Database Backup";
     sd.FileName = "MyDataBase-" + string.Format("{0:dd-MM-yyyy_hh-mm-ss-tt}", DateTime.Now);
     if (sd.ShowDialog() == DialogResult.OK)
     {
      using (bcon = new SqlConnection(constring))
      {
       string sqlStmt = string.Format("backup database [" + System.Windows.Forms.Application.StartupPath + "\\MyDataBase.mdf] to disk='{0}'", sd.FileName);
       using (SqlCommand bu2 = new SqlCommand(sqlStmt, bcon))
       {
        bcon.Open();
        bu2.ExecuteNonQuery();
        bcon.Close();
        MessageBox.Show("Backup Created Sucessfully");
       }
      }
     }
    }
    catch (Exception){MessageBox.Show("Backup Not Created");}
