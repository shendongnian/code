    string userID= Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString();
    
    //For currently logged in user you could use without passing the User.Identity.Name;
    
    string userID= Membership.GetUser().ProviderUserKey.ToString();
    
    viagem = new viagemTableAdapter();
    viagem.GetDataByCliente(userID); 
