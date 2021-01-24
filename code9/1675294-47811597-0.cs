    public DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        FileStream aFile = new FileStream(this.FilePath, FileMode.Open);
        using (StreamReader sr = new StreamReader(aFile, System.Text.Encoding.Default))
        {
            string strLine = sr.ReadLine();
            string[] strArray = strLine.Split(';');
            foreach (string value in strArray)
                dt.Columns.Add(value.Trim());
            DataRow dr = dt.NewRow();
            while (sr.Peek() > -1)
            {
                strLine = sr.ReadLine();
                strArray = strLine.Split(';');
                dt.Rows.Add(strArray);
            }
        }
        return dt;
    }
