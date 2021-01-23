         protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
         {
              Session["PageIndex"] = e.NewPageIndex;
         }
         public void EditSubjectItem()
         {
              GridView1.PageIndex = Session["PageIndex"]
         }
