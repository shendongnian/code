    protected void btn1_Click(object sender, EventArgs e)
        {
            System.IO.TextWriter tw = new System.IO.StringWriter();
            HtmlTextWriter h = new HtmlTextWriter(tw);
            PH1.RenderControl(h);
            string html = tw.ToString();
            DataTable dt = ConvertHTMLTablesToDataTable(html);
            int n = dt.Rows.Count;
            for (int i = 1; i < n; i++)
            {
                string a = dt.Rows[i][0].ToString();
                string b = dt.Rows[i][1].ToString();
                string c = dt.Rows[i][2].ToString();
            }
        }
