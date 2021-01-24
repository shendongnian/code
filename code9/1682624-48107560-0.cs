        private DataSet ds;
        IExcelDataReader reader = null;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = openFileDialog.FileName;
                var file = new FileInfo(tbPath.Text);
                try
                {
                    using (var stream = new FileStream(tbPath.Text, FileMode.Open))
                    {
                        if (reader != null) { reader = null; }
                        // Judge it is .xls or .xlsx
                        if (file.Extension == ".xls") { reader = ExcelReaderFactory.CreateBinaryReader(stream); }
                        else if (file.Extension == ".xlsx") { reader = ExcelReaderFactory.CreateOpenXmlReader(stream); }
                        if (reader == null) { return; }
                        ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            UseColumnDataType = true,
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = false,
                                ReadHeaderRow = (rowReader) => {
                                    rowReader.Read();
                                },
                                // Gets or sets a callback to determine whether to include the 
                                // current row in the DataTable.
                                FilterRow = (rowReader) => {
                                    return true;
                                },
                            }
                        });
                        var tablenames = GetTablenames(ds.Tables);
                        cbSheet.DataSource = tablenames;
                        listSheet.DataSource = tablenames;
                        if (cbSheet.Items.Count == 1)
                        {
                            cbSheet.SelectedIndex = 0;
                        }
                    }
                    cbSheet.Enabled = true;
                    btnOpen.Enabled = true;
                }
                catch (Exception ex)
                {
                    tbPath.Text = "";
                    cbSheet.Enabled = false;
                    btnOpen.Enabled = true;
                    MessageBox.Show(ex.Message);
                }
            }
        }
