    try   
    {   
       ObjPriCon.Open();   
           
    }    
    catch (Exception ex)
    {
       throw ex; 
    }
    finally
    {
      ObjPriCon.close();
    }
