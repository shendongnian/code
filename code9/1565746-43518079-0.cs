       [WebMethod]
        public string GetState() // string instead of void
        {
            string cs = 
          ConfigurationManager.ConnectionStrings["conString2"].ConnectionString;
            List<State> stateList = new List<State>();
            using(SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT StateId,StateName,IsUnionTerritory FROM State_Master ORDER BY StateName ASC", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    State objState = new State();
                    objState.StateId = Convert.ToInt32(dr["StateId"]);
                    objState.StateName = dr["StateName"].ToString();
                    objState.IsUnionTerritory = Convert.ToBoolean(dr["IsUnionTerritory"]);
                    stateList.Add(objState);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(stateList); // return your list
        }
