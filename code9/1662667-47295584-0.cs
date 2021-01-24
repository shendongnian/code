    OleDbDataReader reader = Command.ExecuteReader();
    if(reader.HasRows)
    {
        // Do what you need if there are rows
    }
    else // Instead of an exception handler
    {
        MessageBox.Show("O CNPJ " + ValorConsulta.Text + " não foi localizado no sistema.\nOs dados não podem ter pontuação. Tente novamente", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw new InvalidOperationException(); // If you must throw the exception
    }
