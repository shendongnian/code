    bool Insist(Employee:emp){
      var result = PromptPassword (emp);
      if (result.IsNone)
      {
         return false;
      }
    
      bool matched = result.Where(a => a.EntryContent == emp.Password)
                                  .Some(r => true)
                                  .None(false);
      if(matched)
      {
         return true;
      }else
      {
         return Insist(emp);
      }
   
    }
