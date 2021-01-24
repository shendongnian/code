    // declare class variable
    int x; 
    protected void Page_Load(object sender, EventArgs e)
        {
             // define class variable
             x = 1;
        }
    
        protected void Page_PrerenderComplete(object sender, EventArgs e)
        {
            // use class variable
            if ( x == 1 ) {
                // do stuff
             }
    
        }
