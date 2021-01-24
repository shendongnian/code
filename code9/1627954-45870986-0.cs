      //Reference Project 1 in Project 2 then create a public class 
     // create a public property that stores configuration you want.
     // read the configuration with the ConfigurationManager  
    
     Public Class Datalayer
     
     Public connetionString = 
     ConfigurationManager.ConnectionStrings("connection").ConnectionString
 
