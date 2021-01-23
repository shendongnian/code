    var persons = (
                   // taking Persons table as c
                   from c in context.Persons
                   // now taking PersonStatus table as x and making join
                   // with same key columns of x and c 
                   join x in context.PersonStatus on c.TcKimlik equals x.Tckn
                   join h in hospitals on x.HospitalCode equals h.KURUM_KODU
                   where x.Statu == true
                   //create new model by taking data of different tables of join
                   select new DataViewModel
                   {
                       Id = c.Id,
                       TcKimlik = c.TcKimlik,
                       Uyruk = c.Uyruk,
                       Ad = c.Ad,
                       Soyad = c.Soyad,
                       Cinsiyet = c.Cinsiyet,
                       DogumTarihi = c.DogumTarihi,
                       KurumStatu = h.PAYDAS,
                       KurumKodu = h.KURUM_KODU,
                       KurumAdi = h.KURUM_ADI,
                       BranchName = c.Brans.BranchName,
                       AcademicTitleName = c.AkademikUnvan.Title,
                       ManagerialTitleName = c.IdariUnvan.Title,
                       StaffStatuName = c.Durum.Statu,
                       BranchTypeName = c.Unvan.Type,
                       ServiceClassName = c.Unvan.ServiceClass.Name,
                       City = h.KURUM_ILI,
                       CityCode = h.IL_KODU,
                       CityTownName = h.KURUM_ILCESI
                   }).AsQueryable();
