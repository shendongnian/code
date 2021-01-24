    private bool RootIsRegistered = false; //register Application level var
    
    void Application_BeginRequest(object sender,EventArgs e){
       if(!RootIsRegistered)
          RegisterRoots();
    }
