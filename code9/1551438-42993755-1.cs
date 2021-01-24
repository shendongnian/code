        class Common_Page_Load { // separate .cs file
        
        public bool some_logic() {
         ...
        if(...){
           return true;}
        else{
           return false;}
        }
    }
    Page_Load(...) { //page load of form 1 or form 2 or form 50 or so
    
        if(Session["check_logic"] == "true"){
           Common_Page_Load  CP = new CP();
           bool myvar = CP.some_logic();
           ...
           ...
        }
    
    }
