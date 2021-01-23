    public int Evrno {get; set;} = 21006;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string EVRAKNO = "SP-";
        if (!Page.IsPostBack)
        {
            Evnro+=1;    
        }
 
         // you can add 0 infront of Evnro if it is needed here
         string EvrakNu = EVRAKNO + Convert.ToString(Evnro); 
         txt_EvrakNo.Text = EvrakNu;    
    }
