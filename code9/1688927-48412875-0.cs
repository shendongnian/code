    if (e.Row.RowType == DataControlRowType.Header)
                {
                    string ID = ViewState["ID"].ToString();
                    DataTable dtColumnNames = GetColumns(ID);
                    string[] strColumns = dtColumnText.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
                    for (int i = 0; i < strColumns.Length; i++)
                    {
                        e.Row.Cells[i].Text = "<a href='myUrl'>" + strColumns[i] + "</a>";
                    }
                }
