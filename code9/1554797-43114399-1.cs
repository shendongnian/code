    try
    {
      var conStr = ConfigurationManager.ConnectionStrings["ValidationModuleEntities"].ConnectionString;
    
            using (var conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("[dbo].[ReValidateQuery]", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ValidationRuleKey", ruleKey));
                command.CommandTimeout = 50;
                command.ExecuteNonQuery();
            }
    }
    catch(exception ex)
    {
    
    }
