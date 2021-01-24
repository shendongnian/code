    //putting this all in one sql string to execute in one DB call eliminates the need for C# to manage transactions.
    // If you're nervous about it, you can add "BEGIN TRANSACTION" and "COMMIT" statements to the SQL.
    string sql = "SET IDENTITY_INSERT Bolla ON;\n"
        + "INSERT INTO Bolla (NumeroDDT,IdCantiere,DataDDT,Agente,RagioneSociale,CodiceCliente,RiferimentiInterni,Importo,Destinazione,Filiale,Magazzino,Preparato,Vettore,TipoTrasporto)\n"
        + " VALUES(\n" 
        + "@NumeroDDT, @IdCantiere, @DataDDT, @Agente, @RagioneSociale, @CodiceCliente, @RiferimentiInterni, @Importo, @Destinazione, @Filiale, @Magazzino, @Preparato, @Vettore, @TipoTrasporto);\n"
        + "SET IDENTITY_INSERT Bolla OFF;";
    using (var conn = db.apriconnessione())
    using (var cmd = new SqlCommand(sql, conn))
    {
        //I have to guess at column types and lengths. Update these parameters to match your DB columns
        cmd.Paramerers.Add("@NumeroDDT", SqlDbType.NVarChar, 50).Value = labelNUMDDTMOD.Text;
        cmd.Paramerers.Add("@IdCantiere", SqlDbType.Int).Value = IdCantiere;
        cmd.Paramerers.Add("@DataDDT", SqlDbType.DateTime).Value = Convert.ToDateTime(labelDATADDTMOD.Text);
        cmd.Paramerers.Add("@Agente", SqlDbType.NVarChar, 50).Value = labelAgenteMOD.Text;
        cmd.Paramerers.Add("@RagioneSociale", SqlDbType.NVarChar, 50).Value = labelRagioneSocialeMOD.Text;
        cmd.Paramerers.Add("@CodiceCliente", SqlDbType.Int).Value = int.Parse(labelCodiceClienteMOD.Text);
        cmd.Paramerers.Add("@RiferimentiInterni", SqlDbType.NVarChar, 50).Value = labelRIFInternoMOD.Text;
        cmd.Paramerers.Add("@Importo", SqlDbType.Float).Value = float.Parse(labelImportoMOD.Text); //probably should be double or decimal
        cmd.Paramerers.Add("@Destinazione", SqlDbType.NVarChar, 50).Value = labelDestMOd.Text;
        cmd.Paramerers.Add("@Filiale", SqlDbType.NVarChar, 50).Value = labelFilialeMOD.Text;
        cmd.Paramerers.Add("@Magazzino", SqlDbType.NVarChar, 50).Value = labelMagazzinoMOD.Text;
        cmd.Paramerers.Add("@Preparato", SqlDbType.NVarChar, 50).Value = labelPreparatodaMOD.Text;
        cmd.Paramerers.Add("@Vettore", SqlDbType.NVarChar, 50).Value = labelvettoreMOD.Text;
        cmd.Paramerers.Add("@TipoTrasporto", SqlDbType.NVarChar, 50).Value = labelTipoTrasportoMOD.Text;
        conn.Open();
        cmd.ExecuteNonQuery();
    }
