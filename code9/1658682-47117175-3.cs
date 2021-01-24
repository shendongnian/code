    public partial class MyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void SomeLinkButton_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            int index;
            if (!int.TryParse(button.CommandArgument, out index))
                return;
            //  Do something with 'index'
        }
        protected void FoodDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            lblFoodsCount.Text = "The server return " +
                ((IList<Food>)e.ReturnValue).Count + " foods";
        }
    }
