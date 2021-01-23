    public partial class WebForm1 : System.Web.UI.Page
    {
        List<LoginData> lstLoginData = new List<LoginData>();
        //with this one you check if login was successfull
        public bool loginValidated = false;
        string nameFile = "SomeFile.json";
        // This builds the full qualified filename to your json file and you
        // can use with the standard File.IO methods 
        string WhereIsTheFile = Server.MapPath("~/APP_DATA/" + nameFile);
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!File.Exists(WhereIsTheFile))
            {
                File.Create(WhereIsTheFile);
                ......
            }
            lstLoginData = parsingReadJSONfile(WhereIsTheFile);
            ....
