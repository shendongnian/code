     public void Query_DoSomethingWithItem(List<item> list)
     {
        using(var scope = new TransactionScope()
        {
    
           // using SqlConnection
    
           // fill command-parameter which makes use of a user-defined-table, which represents an array of integers.
    
           conn.Open();
           foreach(var item in list) {
                //initialise the myArray in here
                command.ExecuteNonQuery(item, myArray);
           }
           scope.Complete();
        }
     }
