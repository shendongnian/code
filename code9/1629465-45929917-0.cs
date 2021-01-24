           var dt = new DataTable();
            var lineNo = 0;
            using (var csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                //csvParser.ReadLine();
                while (!csvParser.EndOfData)
                {
                    var fields = csvParser.ReadFields();
                    var rowNums = fields.Length;
                    var row = dt.NewRow();
                    lineNo += 1;
                    int index = 0;
                    for (index = 0; index < rowNums; index++)
                    {
                       
                        if (lineNo==1)
                        {
                            dt.Columns.Add(fields[index]);
                        }
                        else
                        {
                            row[index] = fields[index];
                        }
                       
                    }
                    if (lineNo == 1) continue;
                    dt.Rows.Add(row);
                    dt.AcceptChanges();
                }
                
            }
            dataGridView1.DataSource = dt;
