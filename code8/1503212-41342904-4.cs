         protected void Page_Load(object sender, EventArgs e)
                {
                Page previousPage = Page.PreviousPage;
                if (previousPage != null && previousPage.IsCrossPagePostBack)
                {
                    lblName.ServiceType = ((Label)previousPage.FindControl("lblServiceType")).Text;
                    lblEmail.Method= ((Label)previousPage.FindControl("lblMethod")).Text;
                    //etc bind the remaining label from the previous page
                }
