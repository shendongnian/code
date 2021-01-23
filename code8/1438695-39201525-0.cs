    public bool getdetails()
    {
        bool found = false;
        int id;
        bool isnumber;
        lblMessage.Text = "";
        isnumber = int.TryParse(txtCID.Text, out id);
        if (!isnumber)
        {
            lblMessage.Text = "Please enter a valid Customer ID before obtaining details.";
        }
        else
        {
            command.Connection.Open();
            command.Connection = conn;                
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetCustomer";
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@CustID";
            param.SqlDbType = SqlDbType.Int;
            param.Direction = ParameterDirection.Input;
            param.Value = id;
            command.Parameters.Add(param);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
              txtFName.Text = table.Rows[0].Field<string>("FirstName");
              txtFName.DataBind();
              txtLName.Text = table.Rows[0].Field<string>("Surname");
              txtLName.DataBind();
              rdoGender.Text = table.Rows[0].Field<string>("Gender").ToString();
              txtAge.DataBind();
              txtAge.Text = table.Rows[0].Field<int>("Age").ToString();
              txtAge.DataBind();
              txtAdd1.Text = table.Rows[0].Field<string>("Address1").ToString();
              txtAge.DataBind();
              txtAdd2.Text = table.Rows[0].Field<string>("Address2").ToString();
              txtAge.DataBind();
              txtCity.Text = table.Rows[0].Field<string>("City").ToString();
              txtAge.DataBind();
              txtPhone.Text = table.Rows[0].Field<string>("Phone").ToString();
              txtAge.DataBind();
              txtMobile.Text = table.Rows[0].Field<string>("Mobile").ToString();
              txtAge.DataBind();
              txtEmail.Text = table.Rows[0].Field<string>("Email").ToString();
              txtEmail.DataBind();
              found = true;
            }
            else
            {
               lblMessage.Text = "User with ID " + id + " does not exists";
            }
            command.Connection.Close();
        }
        return found;
    }
