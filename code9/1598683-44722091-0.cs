    try{
        SqlConnection connection = new SqlConnection("YourConnectionstring");
        connection.Open();
        //Your connection string can be found through your Server DB
        //Now you go through your SearchResultCollection populated by SearchResult objects
        foreach(SearchResult res in uniqueSearchResult){
           SqlCommand cmd = new SqlCommand("Select * from yourTable where department=" +res.Properties["department"][0].ToString() + "", connection);
           SqlDataReader reader = cmd.ExecuteReader(); 
           //Here you verify if there are corresponding rows in your table 
           //with the request you have executed
           if(!reader.HasRows()){
               //If you have not found corresponding rows, then you add the department to your
               //list
               addUsersList.Add(res.Properties["department"][0].ToString());
           }
        }  
        connection.close();
    }catch(Exception e){
        Console.WriteLine("Exception caught : \n\n" + e.ToString();
    }
