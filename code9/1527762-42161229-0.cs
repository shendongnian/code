    private void btnPush_Click(object sender, EventArgs e)
        {
            DataSet ds = RunOneStoredProc();
            DataTable teachers = ds.Tables[0];
            DataTable students = ds.Tables[1];
        
        }   
