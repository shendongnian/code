    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            TitleTextBox.Text = ExpTitle;
            StrategyIdTextBox.Text = ExpStrategyId;
            CompanyTextBox.Text = ExpCompany;
        }
        ...
    }
