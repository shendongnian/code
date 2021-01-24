        public static void ExportToExcel(string fileName, string query)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    using (DataTable dt = GetData(cmd))
                    {
                        GridView GridView2 = new GridView();
                        GridView2.AllowPaging = false;
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
                        System.Web.HttpContext.Current.Response.Clear();
                        System.Web.HttpContext.Current.Response.Buffer = true;
                        System.Web.HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", fileName));
                        System.Web.HttpContext.Current.Response.Charset = "HEllo";
                        System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                        {
                            //Apply text style to each Row
                            GridView2.Rows[i].Attributes.Add("class", "textmode");
                        }
                        GridView2.RenderControl(hw);
                        System.Web.HttpContext.Current.Response.Output.Write(sw.ToString());
                        System.Web.HttpContext.Current.Response.Flush();
                        System.Web.HttpContext.Current.Response.End();
                    }
                }
             }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message + "Please try After sometime");
            }
        }
