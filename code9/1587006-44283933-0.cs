        FileUploadControl.SaveAs(Server.MapPath("/public/") + filename);
        FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateBinaryReader(stream);
        DataSet result = excelReader.AsDataSet();
        excelReader.Close();
        result.Tables[0].TableName.ToString();
        string csvData = "";
        int row_no = 0;
        int ind = 0;
        // Please notice 3 and 5 is row and column number with problematic string
        string problematicValue = result.Tables[ind].Rows[3][5].ToString();
        foreach (char c in problematicValue)
        {
            Debug.Print("Character: " + c + " Code " + (int)c);
        }
        output = System.Web.HttpContext.Current.Server.MapPath("/public/target_" + DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy") + ".csv");
        StreamWriter csv = new StreamWriter(@output, false);
        csv.Write(csvData);
        csv.Close();
        csv.Dispose();
