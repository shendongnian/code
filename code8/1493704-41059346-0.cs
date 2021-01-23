    List<SqlParameter> parameters = new List<SqlParameter>();
    parameters.Add(new SqlParameter("@ModuleID ", topic.ModuleID ));
    parameters.Add(new SqlParameter("@Name", topic.Name));
    parameters.Add(new SqlParameter("@BodyHTML", topic.BodyHTML));
    int rowsAffected = SqlHelper.ExecuteNonQuery(constr, "addTopic", parameters.ToArray());
