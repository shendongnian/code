    public static long ScanUpdate(string lotNo)
    {
        string scanLotNo = "";
        int scanIndex = 0;
    
        if (!SplitBarcode(lotNo, ref scanLotNo, ref scanIndex))
        {
            //Invalid Barcode data
            return -919;
        }
    
        //Prepare sql command
        string updStatus = (frmMain.shelfScan) ? "05" : "10";
        string sql = <sql statement>
    
        try
        {
            using (SqlConnection conn = new SqlConection(frmMain.connectionString1)) {
                SqlCommand sqlCmd = new SqlCommand(sql, conn);
                if (sqlCmd.ExecuteNonQuery() <= 0)
                {
                    //No row affect
                    //frmMain.sndPlay.Play();
                    return -99;
                }
                else
                {
                    //Completed
                    return 0;
                }
                conn.Close();
            }            
        }
        catch
        {
            return 99;
        }
    }
