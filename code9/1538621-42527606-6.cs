    public partial class uc1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void uc1Dorpdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // event bubbling
            RaiseBubbleEvent(this, new MyEventArgs
            {
                Value = this.uc1Dorpdown.SelectedItem.Value,
                Text = this.uc1Dorpdown.SelectedItem.Text
            });
        }
    }
