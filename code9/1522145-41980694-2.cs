using System.Web.UI.HtmlControls;
            for (int i = 1; i < 10; i++)
            {
                HtmlInputButton b = this.FindControl("button" + i) as HtmlInputButton;
                if (b != null)
                    b.Disabled = !b.Disabled;
            }
