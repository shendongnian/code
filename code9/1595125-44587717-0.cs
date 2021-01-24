            Maingrid.AllowPaging = false;// To print all the pages without pagination in grid
           
            string filename = string.Empty;
            filename = "Report -" + DateTime.Now.ToString("yyyyMMddHHmmssfffff");
            Response.Clear();
            Response.Buffer = true;
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);          
            Maingrid.GridLines = GridLines.Both;
            Maingrid.HeaderStyle.Font.Bold = true;
           
            int x = Maingrid.Rows.Count;
            for (int i = 0; i < Maingrid.Rows.Count; i++)
            {
                GridViewRow row = Maingrid.Rows[i];
                //Apply text style to each Row
                row.Attributes.Add("class", "textmode");
                row.BackColor = System.Drawing.Color.White;
            }
            Maingrid.RenderControl(hw);
           
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //style to format numbers to string
            Response.Output.Write("<h1>Merchant Registration report</h1>");
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
