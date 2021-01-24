    private void button2_Click(object sender, EventArgs e)
    {
        ServiceReference1.Service2Client obj = new ServiceReference1.Service2Client();
        OpenFileDialog opn = new OpenFileDialog();
        opn.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
        if (opn.ShowDialog() == DialogResult.Cancel)
            return;
        try
        {
            FileStream strm = new FileStream(opn.FileName, FileMode.Open);
            IExcelDataReader excldr = ExcelReaderFactory.CreateOpenXmlReader(strm);
            DataSet rslt = excldr.AsDataSet();
            obj.insertExecl(rslt);
        }
        catch (IOException x)
        {
            MessageBox.Show(x.Message);
        }
    }
