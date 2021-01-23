    try   
    {   
       ObjPriCon.Open();   
          
       bjPriCon.Close();    
    }    
    catch (Exception ex)
    {
       throw ex; 
    }
    finally
    {
      ObjPriCon.close();
    }
