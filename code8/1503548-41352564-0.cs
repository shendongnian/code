    internal class UserDef 
    {
      internal string Login  = "" ; // eventually add password 
      internal bool   Connected = false ;
    }
    
    internal class UserDefs : List<UserDef>
    {
       internal ReleaseUser(UserDef userdef)
       {
         lock(this) { userdef.Connected=false ; }
       }
    
       internal UserDef GetAvailableUser() 
       {
         UserDef result=null ;
         while (result==null) 
         {
           lock(this)
           {
             for (int i=0;i<Count && result==null;i++) if (!this[i].Connected) result=this[i] ;
             if (result!=null) result.Connected = true ;
           }
           system.Threading.Thread.Sleep(200) ;
         }  
       return result ;
       }
    }
  
