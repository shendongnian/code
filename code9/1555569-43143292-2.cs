    if (!Eklenenler.Any(c => c.SequenceEqual(temp)))
    {
        sqlExProjeEkle = "INSERT INTO NLK_PRJ_Webservisler (prjId,wesId) Values (" + prjId + "," + wesId + ")";
        dco.Execute(sqlExProjeEkle);
        Eklenenler.Add(temp);
    }
    else
    {
    }
