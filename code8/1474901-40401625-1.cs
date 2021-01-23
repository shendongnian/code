    public IEnumerable<Personel_Form> OlayForm_Personel() 
        {
            return (from p in Entity.GetEntity().Sicil
                               select new Personel_Form
                               {
                                Id = p.Id,
                                Kimlik = p.Isim + " " + p.Soyad,
                                EMail = p.EMail,
                                DepartmanAdi = p.Departman.DepartmanAdi,
                                PozisyonAdi = p.Pozisyon1.PozisyonAdi
                               }).ToList();
        }
