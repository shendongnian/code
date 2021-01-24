    public partial class About : Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            TextBox txt4 = new TextBox();
            txt4.ClientIDMode = ClientIDMode.Static;
            txt4.ID = "txt4";
    
            TextBox txt5 = new TextBox();
            txt5.ClientIDMode = ClientIDMode.Static;
            txt5.ID = "txt5";
    
            panel1.Controls.Add(txt4);
            panel1.Controls.Add(txt5);
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            btn1.Click += Btn1_Click;
    
            if (IsPostBack)
            {
                System.Web.UI.Control txt4_dynamic = Page.Controls[0].FindControl("MainContent").FindControl("txt4");
                System.Web.UI.Control txt5_dynamic = Page.Controls[0].FindControl("MainContent").FindControl("txt5");
    
                if (txt4_dynamic != null)
                {
                    string str1 = ((TextBox)txt4_dynamic).Text;
                }
    
                if (txt5_dynamic != null)
                {
                    string str1 = ((TextBox)txt5_dynamic).Text;
                }
            }
        }
    
        private void Btn1_Click(object sender, EventArgs e)
        {
            System.Web.UI.Control txt4_dynamic = Page.Controls[0].FindControl("MainContent").FindControl("txt4");
            System.Web.UI.Control txt5_dynamic = Page.Controls[0].FindControl("MainContent").FindControl("txt5");
    
            if (txt4_dynamic != null)
            {
                string str1 = ((TextBox)txt4_dynamic).Text;
            }
    
            if (txt5_dynamic != null)
            {
                string str1 = ((TextBox)txt5_dynamic).Text;
            }
        }
    }
