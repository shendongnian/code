    int parameterValue;
    SqlParameter parameter = new SqlParameter("@courseID", SqlDbType.Int);
    if(Int32.TryParse(comboBoxcourse1.SelectedValue?.ToString() ?? String.Empty, out parameterValue))
    {
      parameter.Value = parameterValue;
    }
    else
    {
      parameter.Value = DBNull.Value;
    }
    cmd.Parameters.Add(parameter);
