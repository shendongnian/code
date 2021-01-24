    public abstract class BaseClass : UserControl
    {
        protected override void OnLoad(EventArgs e)
        {
            if (this.Visible)
            {
                base.OnLoad(e);
            }
        }
    }
    public partial class WebUserControl1 : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // running only if this.Visible = true
        }
    }
