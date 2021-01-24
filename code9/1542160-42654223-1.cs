    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            HtmlGenericControl testes = new HtmlGenericControl("DIV");
            testes.ID = "Div_Cabos_Rede";
            testes.Attributes.Add("class", "col-md-12 letra");
            testes.InnerHtml = "Cabos de rede";
            TextBox Cabos_de_rede = new TextBox();
            Cabos_de_rede.ID = "Txt_Cabos_Rede";
            Cabos_de_rede.Attributes.Add("class", "col-md-12 form-control");
            testes.InnerHtml = "Cabos de rede";
            PlaceHolder1.Controls.Add(testes);
            PlaceHolder1.Controls.Add(Cabos_de_rede);
        }
    
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            TextBox testar = FindControlRecursive(PlaceHolder1, "Txt_Cabos_Rede") as TextBox;
            ResultLabel.Text = testar.Text;
        }
    
        // Custom method to search a control recursively 
        // in case it is nested inside other control. 
        // You can create it as an extension method if you would like.
        public static Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
                return root;
    
            return root.Controls.Cast<Control>()
                .Select(c => FindControlRecursive(c, id))
                .FirstOrDefault(c => c != null);
        }
    }
