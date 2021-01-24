      private void dosyasec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx*", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                    var result = reader.AsDataSet(
                        new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        }
                    );
                    comboBox1.Items.Clear();
                    foreach (DataTable dt in result.Tables)
                        comboBox1.Items.Add(dt.TableName);
                    reader.Close();
                }
            }
    
        }
