        protected void ExportToExcelPosterWay(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //To Export all pages
                GridView1.AllowPaging = false;
                //Search(null, null);
                initializeGridView();
                // GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    // row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                    //table.Rows.Add(title);
                }
                //GridView1.Columns[7].Visible = false;
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Write("Some cool text added before the grid");
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
