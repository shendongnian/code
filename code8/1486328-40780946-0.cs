           public class Table1
           {
              public string col1{get;set;}//set the properties
           }
           public class Table2
           {
            public string col1{get;set;}//set the properties
           }
         public class CombileResult
         {
             public Table1 objtable1{get;set;}
             public Table2 objtable2{get;set;}
          }
        using(SqlConnection con = new SqlConnection(connectionString'))
            {
              SqlCommand cmd = new SqlCommand(query, con);
              con.Open();
              using(SqlDataReader reader = cmd.ExecuteReader())
              {
                while(reader.Read())
                {
                CombileResult objCombine=new objCombine();
                 objCombine.objtable1=//content for table 1
                 objCombine.objtable2=//content for table 2
                }
              }
            }
             
