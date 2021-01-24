      public void Update() //CALLED IT void FUNCTION earlier
            {
    
                while (true)
                {
                    while (getResponse(jsonUrl))
                    {
    
    
                        jList = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<jsonList>(GET(jsonUrl));
   
     //I DO SOME STUFF HERE
     //INTERESTING STUFF
    
                       
                        Thread.Sleep(5000);
    
                    }
                    
                }
            
    
            }
 
