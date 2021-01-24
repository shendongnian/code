    protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int x = 0; x <= 3; x++)
                {
                    GridViewRow rows = (GridViewRow)gdView.HeaderRow.Parent.Controls[x];
                    rows.BackColor = Color.White;
                    rows.Height = 15;
                    for (int i = 0; i <= rows.Cells.Count - 1; i++)
                    {
                        rows.Cells[i].BackColor = Color.Maroon;
                    }
                } 
                foreach (GridViewRow row in gdView.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        cell.VerticalAlign = VerticalAlign.Middle;
                        cell.CssClass = "textmode";
                    }
                }
                gdView.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            // controller   
        }
