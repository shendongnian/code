    protected void Page_Load(object sender, EventArgs e)
    {
       populate();
    }
    void populate()
    {
       HtmlGenericControl ulList = new HtmlGenericControl("ul");
       panel.Controls.Add(ulList);
       foreach (DataRow dr in drc) 
       {
          HtmlGenericControl liList = new HtmlGenericControl("li");
          ulList.Controls.Add(liList);
          if (liList.FindControl(dr["col1"].ToString()) == null)
          {
              var lnk = new LinkButton();
              lnk.ID = dr["col1"].ToString();
              lnk.Text = dr["col1"].ToString();
              lnk.Click += Clicked;
              liList.Controls.Add(lnk);
          }
       }
    } 
