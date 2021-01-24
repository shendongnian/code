    catch (Exception ex)
    {
       DatabaseEntity DbObj = new DatabaseEntity();
       ExceptionTable ExObj = new ExceptionTable();
       ExObj.ExceptionName = ex.Message;
       ExObj.InnerException = ex.InnerException;
       .....
       //Code according to your need
       .....
       
       DbObj.ExceptionTable.Add(ExObj);
       DbObj.SaveChanges();
       MessageBox.Show(ex.Message);  
    }
