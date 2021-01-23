        public string connectionString = "Data Source = YOUCANSEEONSQLSERVER; Initial Catalog = DATABASENAME; User Id = sa; Password = sqlpasswordifyouuse";
        private void Valetin_Load(object sender, EventArgs e)
        {
            OPIDCB.ResetText();
            ValetCB.ResetText();
            SqlConnection sqlconn = new SqlConnection(pr.connectionString);
            SqlCommand sqlselect1 = new SqlCommand("Select EmpID, EmpName from Employees.Employee where IDPosition = 'OP'", sqlconn);
            sqlconn.Open();
            SqlDataReader dr1 = sqlselect1.ExecuteReader();
            while (dr1.Read())
            {
                ArrayList MyAL = new ArrayList();
                ArrayList MyAL2 = new ArrayList();
                MyAL.Add(dr1.GetString(0));
                MyAL2.Add(dr1.GetString(1));
                foreach (string s in MyAL)
                    foreach (string s2 in MyAL2)
                    {
                        OPIDCB.Items.Add(s + " " + s2);
                    }
                OPIDCB.SelectedIndex = 0;
            }
            dr1.Close();
            sqlconn.Close();
        }
