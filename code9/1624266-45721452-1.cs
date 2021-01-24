    try
    {
        using MySqlConnection con = new MySqlConnection(conString)
        {
        MySqlDataAdapter da = new MySqlDataAdapter();
        using MySqlCommand cmd = new MySqlCommand(sqlCMD, con)
        {
        RSACryptoServiceProvider.UseMachineKeyStore = true;
        var provider = new RSACryptoServiceProvider();
        con.Open();
        da.SelectCommand = cmd;
        da.Fill(dt);
        }
    }
    }
    catch (MySqlException x)
    {
        //Error logic
    }
    catch (Exception ex)
    {
    }
