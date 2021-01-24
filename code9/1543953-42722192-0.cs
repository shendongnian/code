    public partial class TestControl : UserControl
    {
        protected static Dictionary<string, string> _endpoints = 
                                          new Dictionary<string, string>();
        
        //lock object needs to be static in this case
        private static object _lockObject = new object();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lock(_lockObject) //only one thread may pass at the same time,
                              //others will wait.
            {
                //clear the lists of endpoints each time the page is loaded
                _endpoints.Clear();
                ...
                MethodThatAddsToDictionary();
             }
         }
         public static void MethodThatAddsToDictionary()
         {
             ...
             _endpoints.Add(response.First(), response.Last());
         }
     }
