     SqlConnection sqlConnection=new SqlConnection("Your Sql Server Connection");
                SqlDataAdapter sqlDataAdapter=new SqlDataAdapter("Select * From Roles",sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                comboBoxRoles.DisplayMember = "RoleName";
                comboBoxRoles.ValueMember = "RoleId";
                comboBoxRoles.DataSource = dataSet;
