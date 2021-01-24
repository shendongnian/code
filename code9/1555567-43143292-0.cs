    if (!Eklenenler.Select(c => c.SequenceEqual(temp)).Contains(true))
    {
        sqlExProjeEkle = "INSERT INTO NLK_PRJ_Webservisler (prjId,wesId) Values (" + prjId + "," + wesId + ")";
        dco.Execute(sqlExProjeEkle);
        Eklenenler.Add(temp);
    }
    else
    {
    }
