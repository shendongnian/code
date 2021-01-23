    private string[,] links = links[40, 40];
    
    for(int i = 0; i < 40; i++)
    {
        Link(i, links);
        
        // here, your links array variable contain values from [0, 0] through [40, 40]
        //...rest of the code.
    }
    string[] Link(int i, string[,] arr)
    {
        // no need to create a new array
        //connection open and other code (before sqlDataReader.Read() line)
        while (sqlDataReader.Read())
        {
           arr[i , num] = sqlDataReader.GetValue(0).ToString(); 
           num++;
        }
        //rest of the code and return statement
    }
 
