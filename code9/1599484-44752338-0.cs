    SqlConnection con = new SqlConnection("ConnectionString");
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from Project Table where ActaulStartDate is null and ActualEndDate is null";
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "ProjectName";
                comboBox1.ValueMember = "ProjectID";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
