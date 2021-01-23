    private void changeTheme()//this metod working in MasterPage.
            {
                for (int i = 0; i < Page.Controls[0].Controls.Count; i++)//returns masterpage
                {
                    if (Page.Controls[0].Controls[i].GetType().ToString() == "System.Web.UI.HtmlControls.HtmlForm")//find htmlform in masterpage
                    {
                        foreach (var item in Page.Controls[0].Controls[i].Controls)//find all controls in htmlform
                        {
                            if (item is ASPxWebControl)//reach all devexpress controls
                                (item as ASPxWebControl).Theme = "Metropolis";//change their theme
                        }
                        break;
                    }
                }
                for (int i = 0; i < this.ContentPlaceHolder1.Controls.Count; i++)//find derived page's controls from masterpage
                {
                    if (this.ContentPlaceHolder1.Controls[i] is ASPxWebControl)//and reach them
                        (this.ContentPlaceHolder1.Controls[i] as ASPxWebControl).Theme = "Metropolis";
                }
            }
