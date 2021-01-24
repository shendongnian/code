    #region Bind Social
    
        private void BindSocial(string hdnsocial)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            BD_Doctor iDoctor = new BD_Doctor();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Doctorsocialnetwork where DoctorID = '" + hdnsocial + "'", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptsocial.DataSource = dt;
                        rptsocial.DataBind();
                    }
                }
            }
        }
    
        #endregion
