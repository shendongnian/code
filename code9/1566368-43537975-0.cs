    List< IletisimLog> bulkInsertIletisimLog = new List<IletisimLog>();
    //there are 1000 values in the array of paramaters
    foreach (var kId in paramaters)
    {     
        var iletisimLogInsert = new IletisimLog()
        {
            KullaniciID = kId.KullaniciId,
            EklendigiTarih = DateTime.Now,
            GonderildigiTarih = DateTime.Now,
            BilgilendirmeTurID = bilgilendirmeturId,
        };
        bulkInsertIletisimLog.Add(iletisimLogInsert);    
    }
    _iLetisimLogService.BulkInsertRange(bulkInsertIletisimLog);
    foreach (var inserted in bulkInsertIletisimLog)
    {
        // Get the ID of the inserted object
        var newId = inserted.Id;
    }
