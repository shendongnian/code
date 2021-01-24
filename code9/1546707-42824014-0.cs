    int modele = 0;
    if(int.TryParse(modele_vehiclue.Text, out modele)
    {
       cmd.Parameters.Add("@modele", SqlDbType.Int).Value = modele;
    }
    else
    {
        // display message that invalid input
    }
