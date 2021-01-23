    public object OlayForm_Personel() 
        {
            return (from p in Entity.GetEntity().Sicil
                               select new 
                               {
                                Id = p.Id,
                                Kimlik = p.Isim + " " + p.Soyad,
                                EMail = p.EMail,
                                DepartmanAdi = p.Departman.DepartmanAdi,
                                PozisyonAdi = p.Pozisyon1.PozisyonAdi
                               }).ToList();
        }
