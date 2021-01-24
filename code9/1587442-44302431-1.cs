    public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpRequest q = Request;
        string v = q.QueryString["one"];
        if (v != null)
        {
        }
        v = q.QueryString["two"];
        if (v != null)
        {
        }
    }
