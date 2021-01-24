    foreach (var item in bytes)
    {
      DbCommand.CommandText = "INSERT INTO HUELLAS VALUES(@param1,@param2)";                
      DbCommand.Parameters.Add("@param1",SqlDbType.NVarchar).Value = hola;
      DbCommand.Parameters.Add("@param2",SqlDbType.VarBinary).Value = item;
      int result = DbCommand.ExecuteNonQuery();
      if (result> 0)
      {
         LabelMs.Text = $"El estudiante ha sido registrado correctamente for entry {item}";
      }
      else
      {
         LabelMs.Text = $"Hubo un problema al momento de registrar a este usuario for entry {item}";
      }
    }
