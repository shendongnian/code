    namespace BindingExample
    {
        public partial class LabelText: System.Web.UI.Page
        {
            public Show _show; //this will allow this object to be used in aspx page
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
