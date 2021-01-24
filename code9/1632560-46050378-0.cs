    // Declare a model, with a property/field for every column
    // that you care about from your Result
    public class YourModel {
     
        public int Id {get;set;}
        // Whatever other columns your result has...
    }
    public class GetDataFromProc
    {
        string constr;
        public IEnumerable<YourModel> CallProcToDataSet(string procName)
        {
            constr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
    
            using (SqlConnection con = new SqlConnection(constr))
            {
                // If you expect only one row
                var result = cnn.Query<YourModel>(procName, new { anyParametersYouHave = theirValue }, commandType: CommandType.StoredProcedure).SingleOrDefault();
    
                // If you expect more than one row and want a collection
                var results= cnn.Query<YourModel>(procName, new { anyParametersYouHave = theirValue }, commandType: CommandType.StoredProcedure).ToList();
    
            }
        }
     }
