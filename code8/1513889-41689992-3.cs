    private void ReadCSVFile(string filepath)
    {
        //receiverList = new List<ReceiverUser>();
        
        try
        {
            if (filepath == string.Empty)
                return;
            using (StreamReader sr = new StreamReader(FileUpload1.PostedFile.InputStream))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    SplitLine(line);
                }
            }
            #region row add test
            DataTable dt = new DataTable();
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Mail", typeof(string));
                dt.Columns.Add("Amount", typeof(double));
            }
            DataRow NewRow;
    /*
            foreach (var item in receiverList)
            {
                NewRow = dt.NewRow();
                NewRow[0] = item.Name + " " + item.Surname;
                NewRow[1] = item.Mail;
                NewRow[2] = item.Amount;
                dt.Rows.Add(NewRow);
            }
    */
            grdRec.DataSource = dt;
            grdRec.DataBind();
            #endregion
        }
        catch (Exception)
        {
        }
    }//end of function
