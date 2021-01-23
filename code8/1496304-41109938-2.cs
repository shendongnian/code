    public void InsertPaciente (Paciente paciente) 
    {
        string sqlInsert;
        // dispose when done
        using(DbConnection connection = new SQLiteConnection(urlDataBase))
        {
            // dispose when done
            using(IDbCommand command = connection.CreateCommand())
            {
                // use named parameters 
                // https://www.sqlite.org/c3ref/bind_blob.html
                sqlInsert = @"INSERT INTO paciente 
                    (cpf, nome, sexo, endereco, email, dataNascimento, telefone, numeroConsultas)
                    VALUES 
                    (@Cpf, @Nome, @Sexo, @Endereco, @Email, @DataNascimento, @Telefone, @NumeroConsultas 
                    );";
            
                connection.Open();
                command.CommandText = sqlInsert;
                // for each parameter, add the name of the bind-parameter and the value 
                command.Parameters.Add(new SQLiteParameter("Cpf",paciente.Cpf));
                command.Parameters.Add(new SQLiteParameter("Nome", paciente.Nome));
                command.Parameters.Add(new SQLiteParameter("Sexo", paciente.Sexo));
                command.Parameters.Add(new SQLiteParameter("Endereco", paciente.Endereco));
                command.Parameters.Add(new SQLiteParameter("Email", paciente.Email));
                command.Parameters.Add(new SQLiteParameter("DataNascimento", paciente.DataNascimento));
                command.Parameters.Add(new SQLiteParameter("Telefone", paciente.Telefone));
                command.Parameters.Add(new SQLiteParameter("NumeroConsultas", paciente.NumeroConsultas));
                //Debug.Log (sqlInsert);
                command.ExecuteNonQuery();
            }
        }
    }
