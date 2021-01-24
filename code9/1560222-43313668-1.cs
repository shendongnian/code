    namespace BindingExample
    {
        public partial class LabelText: System.Web.UI.Page
        {
            protected Show _show;
            protected void load_page(object sender, Event args)
            {
                _show = new Show
                {
                    ID = 1,
                    ShowName = "C# is the Best"
                };
    
                Page.DataBind();
            }
        }
    }
