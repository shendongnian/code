       public bool Login(LoginCrediential Login)
                {
                    var x = (from n in db.LoginCrediential
                            where n.UserName == Login.UserName && n.Password == Login.Password select n).FirstOrDefault();
                    if (x != null){
                      var roleOfTheUser = x.Role;
                      return true;}
                    else return false;  
    
