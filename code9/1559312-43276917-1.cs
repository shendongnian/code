    IEnumerable<int> Ids;
    protected void Page_Load(object sender, EventArgs e)
            {
    
                if (!IsPostBack)
                {
                     Ids = GetIds();
    
                 }
        }
     public IEnumerable<int> GetIds()
       {
            IEnumerable<int> IdsToReturn;
            using ()
            {
                   //Here you can get Ids;  
                   //query to get data from back end
            }
            return IdsToReturn;
        }
