    private const string ENTITY_KEY = "c335a928-72ac-4403-b5f8-418f1e5ac1ec";
    
    protected void Page_Load(object sender, EventArgs e) {
          if( !this.IsPostBack ) {
    
          Session.Add( "ENTITY_KEY", ENTITY_KEY );
       }
    
    }
    
    protected void Button1_Click(object sender, EventArgs e) {
       string s = Session[ "ENTITY_KEY" ].ToString();
    }
