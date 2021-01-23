     public void fill_combobox_users()
        {
            // auto-complete
            comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            da = new SqlDataAdapter("select ID_EMP,(NOM_EMP+ ' ' + PRENOM_EMP) AS NOMM from EMPLOYE", cn);
            DataTable dt = new DataTable();
            try
            {
                cn.Open();
                da.Fill(dt);
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = dt.Columns[1].ColumnName;
                comboBox3.ValueMember = dt.Columns[0].ColumnName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
