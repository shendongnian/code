    public partial class createHtmlFormsForm : Form
    {
     List<field> listOfFields = new List<field>();
     string username = "";
     public createHtmlFormsForm(string username1)
     {
        username = username1;
        InitializeComponent();
     }
    // private contructor with no parameter
     private createHtmlFormsForm()
     {
        InitializeComponent();
     }
    }
