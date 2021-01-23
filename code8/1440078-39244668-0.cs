            protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            BindData();
            GridView1.Visible = true;
            string FileName = "Deal Report_(" + DateTime.Now.AddHours(5).ToString("yyyy-MM-dd") + ").xls";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.HeaderRow.Style.Add("color", "#FFFFFF");
            GridView1.HeaderRow.Style.Add("background-color", "#1F437D");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
                row.BackColor = System.Drawing.Color.White;
                row.Attributes.Add("class", "textmode");
                if (i % 2 != 0)
                {
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        //row.Cells[j].Style.Add("background-color", "#eff3f8");
                    }
                }
            }
            GridView1.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.End();
            GridView1.Visible = false;
        }
