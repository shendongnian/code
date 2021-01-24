        cmd.CommandText = "Insert into USER.Client VALUES (:param_txtBoxClientName, :param_txtBoxClientCity, :param_txtBoxClientCountry, :param_txtBoxClientNumber, :param_txtBoxClientURL, :param_comboClientStatus)";
		cmd.Parameters.Add(new OracleParameter("param_txtBoxClientName", OracleDbType.Varchar2, txtBoxClientName.Text, ParameterDirection.Input));
		cmd.Parameters.Add(new OracleParameter("param_txtBoxClientCity", OracleDbType.Varchar2, txtBoxClientCity.Text, ParameterDirection.Input));
		cmd.Parameters.Add(new OracleParameter("param_txtBoxClientNumber", OracleDbType.Varchar2, txtBoxClientNumber.Text, ParameterDirection.Input));
		cmd.Parameters.Add(new OracleParameter("param_txtBoxClientURL", OracleDbType.Varchar2, txtBoxClientURL.Text, ParameterDirection.Input));
