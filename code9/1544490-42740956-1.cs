    public partial class MyPage : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            SomeClass.Foo(this);
        }
    }
