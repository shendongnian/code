    else if (textBox3.Text.Contains("GEN_EX"))
    {
        foreach (DataTable dt in result.Tables)
        {
            foreach (DataRow dr in dt.Rows)
            {
                GEN_EX addtable = new GEN_EX()
                {
                    EX_ID = Convert.ToByte(dr[0]),
                    DOC_ID = Convert.ToByte(dr[1]),
                    PATIENT_NO = Convert.ToByte(dr[2]),
                    TEST_DATE = Convert.ToDateTime(dr[3]),                    
                    **TEST_TIME = GetTimeSpan(dr[4].ToString()),**
                };
                conn.GEN_EXs.InsertOnSubmit(addtable);
            }
        }
        conn.SubmitChanges();
        MessageBox.Show("File uploaded successfully");
    }
