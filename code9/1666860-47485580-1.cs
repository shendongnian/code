    [WebMethod]
        public static string Complextype(string Nam, string Loadin, string Mobil, string EmailI)
        {
            string Qtets = "Details are : Name =" + Nam + " And Designation is =" + Loadin + " And Mobileno=" + Mobil + " And EmailI=" + EmailI;
            //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "test", "<script>alert('Sorry This Category Name Already Exist.');</script>", false);
    
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_add_upd_emptb", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpName", Nam);
                cmd.Parameters.AddWithValue("@EmpNo", Mobil);
                cmd.Parameters.AddWithValue("@Desig", Loadin);
                cmd.Parameters.AddWithValue("@Email", EmailI);
                cmd.Parameters.AddWithValue("@id", 0);
    
                con.Open();
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    con.Open();
                }
            }
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
            //{
            //}
    
            return Qtets;
        }
