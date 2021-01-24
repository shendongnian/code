           var filePath = txtExcelFile.Text;
            using (var stream = File.Open(filePath,FileMode.Open,FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var ds = reader.AsDataSet();
                }
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
