    public partial class createHtmlFormsForm : Form
    {
     List<field> listOfFields = new List<field>();
     string username = "";
     public createHtmlFormsForm(string username1)
     {
        username = username1;
        InitializeComponent();
     }
     public createHtmlFormsForm()
     {
        InitializeComponent();
     }
    }
