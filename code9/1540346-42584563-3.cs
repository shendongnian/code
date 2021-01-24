    String Query3 = "Update Articolo set Articolo.Stato = 'Disponibile',Articolo.Prezzo = TabellaTemp.PRZNETTO,Articolo.PrezzoListino = TabellaTemp.PRZCASA,Articolo.DataAggiornamento = TabellaTemp.DATAAGG,Articolo.Descrizione = TabellaTemp.DESCR,Articolo.UM = TabellaTemp.UM from Articolo inner join TabellaTemp on TabellaTemp.CodMarca = Articolo.CodMarca and TabellaTemp.CODART = Articolo.CodArt where Articolo.Importato = 'COMET' ";
    cmdTemp = Nothing;
    cmdTemp = new SqlCommand(Query3, conn);
    // Setting command timeout to 2 minutes
    cmdTemp.CommandTimeout = 120;
    cmdTemp.ExecuteNonQuery();
