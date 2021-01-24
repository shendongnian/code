    public class MyEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        //Other properties
    
    }
    
    //...
    
    SqlCommand getColumns = new SqlCommand("SELECT * FROM tableName", 
    connection1);
    
    var myDataFromTable = new List<MyEntity>();
    
    myReader = getColumns.ExecuteReader();
    while (myReader.Read())
    {
        myDataFromTable.Add(new MyEntity {
                Name = myReader[0] as string,
                Age = (int)myReader[1]
                //...
            });
    }
    //Process your list of entities here
