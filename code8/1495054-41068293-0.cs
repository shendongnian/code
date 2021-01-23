    protected void addmainDiv(int m)
    {             
        for(int i = 0; i< m; i++)
        {
          System.Web.UI.HtmlControls.HtmlGenericControl newdivs = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
          newdivs.Attributes.Add("class", "maindivs");
          maindivs.Controls.Add(newdivs);
       }
                    
    }
 
