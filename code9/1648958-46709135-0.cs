    public void RegistroHuella(ComboBox ComboBx, Label LabelMs, Byte[] bytes)
    {
        try
        {
            int hola = ComboBx.SelectedIndex;
            
            ConexionHuella();
            
            using (var command = DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT TOP 1 ID FROM HUELLAS WHERE ID = @hola";
                command.Parameters.AddWithValue("@hola", hola);
                
                if (command.ExecuteScalar() != null)
                {
                    LabelMs.Text = "El estudiante ya existe en la base de datos";
                    return;
                }
            }
            
            using (var command = DbConnection.CreateCommand())
            {
                command.CommandText = "INSERT INTO HUELLAS VALUES (@hola, @bytes)";
                command.Parameters.AddWithValue("@hola", hola);
                command.Parameters.AddWithValue("@bytes", bytes);
                
                int recordsAffected = command.ExecuteNonQuery();
                if (recordsAffected > 0)
                {
                    LabelMs.Text = "El estudiante ha sido registrado correctamente.";
                }
                else
                {
                    LabelMs.Text = "Hubo un problema al momento de registrar a este usuario.";
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            //LabelMs.Text = ex.Message;
        }
        finally
        {
            DbConnection.Close();
        }
    }
