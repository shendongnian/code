    public List<Telefone> CarregarTelefone(string contactId)
    {
        var cursor = this.ContentResolver.Query(ContactsContract.CommonDataKinds.Phone.ContentUri, new string[] { Phone.Number }, ContactsContract.CommonDataKinds.Phone.InterfaceConsts.ContactId + "=" + contactId, null, null);
        List<Telefone> litel = new List<Telefone>();
            
        while (cursor.MoveToNext())
        {
            Telefone tele = new Telefone();
            tele.NumeroTelefone = cursor.GetString(0);
            litel.Add(tele);
        }
        return litel;
    }
