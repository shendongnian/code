                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT NAME,ADDRESS FROM TBL_STUDENT", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd );
                DataSet DT = new DataSet();
                da.Fill(DT );                           
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = DT.Tables[0];
                GridView1.DataBind();
                con.Close();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                 "attachment;filename=StudentsData_" + System.DateTime.Now + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
