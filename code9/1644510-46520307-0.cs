    // a class member
    private string connectionString; 
    
    // In your constructor
    connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        
    private void set_data_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var query = "Select SY_DID, S_ID as 'SYMPTOM NO', SD_ID as 'DISK NO', m.med_name as 'MED NAME', SRO, PNR, SYM as '% SYM', DMD" +
                    " from SYM_DETAIL sd" +
                    " inner join MEDICINE m on sd.MED_ID=m.med_Id" +
                    " where sd.S_ID = @S_ID" +
                    " and sd.SD_ID= @SD_ID";
        using(var con = new SqlConnection(connectionString)
        {
            using(var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@S_ID", SqlDbType.VarChar).Value = txtbxsymid_update.Text;
                cmd.Parameters.Add("@SD_ID", SqlDbType.VarChar).Value = txtbxdiskid_update.Text;
                using(var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds, "SYM_DETAIL");
                }
            }
        }
        dataGridView1.DataSource = ds.Tables[0];
    }
