    // an array of type int with 3 values is present
    foreach(var item in list)
    {
      //Pseudocode incoming
      Query_DoSomethingWithItem(item.Identifier, myArray)
    }
    int[] DoSomethingWithItem(long id)
    {
      var result = new List<int>();
      using(var scope = new TransactionScope()
      {
         using(var con = new SqlConnection())
         {
           using(var cmd = new sqlcommand())
           {
             con.Open();      
             cmd.ExecuteNonQuery();     
             // fill your list of integers.        
             scope.Complete();
          }
        }
      }
      return result.ToArray();
    }
