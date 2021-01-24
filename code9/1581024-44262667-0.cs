        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            else
            {
                    for (int i = 1; i <= 5; i++)
                    {
                        if (pnlAnswer2.ContentTemplateContainer.FindControl("tbscore" + i) == null)
                        {
                            this.CreateTable(i);
                        }
                    }
            }
        }
         private void CreateTable(int id)
        {
            TextBox txt = new TextBox();
            txt.ID = "txtScore" + id;
            txt.CssClass = "txt_standard";
            txt.TextMode = TextBoxMode.SingleLine;
            txt.Style.Add("width", "50px");
            txt.Attributes.Add("runat", "server");
            Table tb = new Table();
            tb.ID = "tbscore" + id;
            tb.Attributes.Add("runat", "server");
            tb.BorderWidth = Unit.Pixel(0);
            for (int i = 1; i <= 1; i++)
            {
                TableRow tr = new TableRow();
                TableCell td3 = new TableCell();
                td3.Controls.Add(txt);
                td3.Style.Add("padding-top", "15px");
                tr.Cells.Add(td3);
                tb.Rows.Add(tr);
            }
            pnlAnswer2.ContentTemplateContainer.Controls.Add(tb);
            tb.Visible = false;
        }
