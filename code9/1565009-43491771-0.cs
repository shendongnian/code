    public List<string> consultaBaseDatos(){
        List<string> listEmails= new List<string>();    
        //Here I connect to the database and get the records.
        //Then I run the records with a while ...
         while(myreader.Read())
         {
             string email=myreader["emails"].ToString());
             if(this.enviarCorreo(email)
             {
                    /**This is where I should call the fieldTextBox event, but I am unable to do so.**/
                    listEmails.Add(email);
             }
         }
         return listEmails;
    }
