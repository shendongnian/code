    cmd.CommandType = CommandType.Text;
    cmd.CommandText = 
       "UPDATE SLAPTEOP SET XOCL = :xocl, 
           NOM = :mom, ETAT = -1, 
           NBPAAN = 11, DESCRIPTION = :desc, 
           APPORTEUR = :apporteur, AUTEUR_MISEAJOUR = :auteur, 
           DATE_MISEAJOUR = SYSDATE
    	WHERE OID = :oid";
    
    cmd.Parameters.Add("xocl", OracleDbType.Varchar2, ParameterDirection.Input).Value = atoEntity.OidOcl;
    cmd.Parameters.Add("mom", OracleDbType.Varchar2, ParameterDirection.Input).Value = atoEntity.NameAto;
    cmd.Parameters.Add("desc", OracleDbType.Varchar2, ParameterDirection.Input).Value = atoEntity.DescriptionAto;
    cmd.Parameters.Add("apporteur", OracleDbType.Varchar2, ParameterDirection.Input).Value = atoEntity.ContributorAto;
    cmd.Parameters.Add("auteur", OracleDbType.Varchar2, ParameterDirection.Input).Value = atoEntity.AuthorUpdateAto;
    cmd.Parameters.Add("oid", OracleDbType.Varchar2, ParameterDirection.Input).Value = atoEntity.OidAto;
    
    var r = cmd.ExecuteNonQuery();
    Console.WriteLine("{0} rows updated", r);
