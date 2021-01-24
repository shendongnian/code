    if (GMDSP1.Rows.Count > 0)
                {
                 DataTable _dt1 = new DataTable();
                 DataTable _dt2 = new DataTable();
                    DataGridViewRow gvdr = GMDSP1.CurrentRow;
                    DataRow[] drArr = _dt1.Select("Name= '" + gvdr.Cells["Name1"].Value.ToString() + "'");
                    if (drArr.Length > 0)
                    {
                        DataRow dr = _dt2.NewRow();
                        if (_dt2.Columns.Count == 0)
                        {
                            foreach (DataColumn dc in _dt1.Columns)
                            {
                                DataColumn newDC = new DataColumn(dc.ColumnName, dc.DataType);
                                _dt2.Columns.Add(newDC);
                            }
                        }
                        dr["ID"] = drArr[0]["ID"].ToString();
                        dr["Name"] = drArr[0]["Name"].ToString();
                     
                       
                            _dt2.Rows.Add(dr);
                            _dt1.Rows.Remove(drArr[0]);
                            _dt1.AcceptChanges();
                            _dt2.AcceptChanges();
                        
                        GMDSP1.DataSource = _dt1;
                        GMDSP2.DataSource = _dt2;
