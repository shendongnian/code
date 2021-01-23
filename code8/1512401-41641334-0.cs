    public void Run(Action<int> update) 
    {
        using (SqlConnection conn = new SqlConnection(_myHost))
        {
           conn.Open();
           int index = 0;
           foreach (string item in myList)
           {
              //Perform query
              //Notify the caller of progress
              update(index);
              index++
           }
        }
    }
