    using System.Data.SqlClient;
    using System.Web.Configuration;
    protected void btnBackup_Click(object sender, EventArgs e)
        {
            string conToDBString = WebConfigurationManager.ConnectionStrings["connectionToSqlServer"].ConnectionString;
            SqlConnection conToDB = new SqlConnection(conToDBString);
            conToDB.Open();
            string str = "USE [NameOfDatabase];";
            string str1 = "BACKUP DATABASE [NameOfDatabase] TO DISK = 'C:\\Temp\\BackupForDB.bak' WITH FORMAT,MEDIANAME = 'Z_SQLServerBackups',NAME = 'Full Backup of NameOfDatabase';";
            SqlCommand cmd1 = new SqlCommand(str, conToDB);
            SqlCommand cmd2 = new SqlCommand(str1, conToDB);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            conToDB.Close();
        }
