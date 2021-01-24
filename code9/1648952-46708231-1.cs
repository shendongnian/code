    foreach (var item in bytes)
    {
      DbCommand.CommandText = "INSERT INTO HUELLAS VALUES(@param1,@param2)";                
      DbCommand.Parameters.Add("@param1",hola)
      DbCommand.Parameters.Add("@param2",item)
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
