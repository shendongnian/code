     public IHttpActionResult TalepListele(TalepList model)
        {
            List<TalepList> detay = new List<TalepList>();
            using (var ctx = new ktdbEntities())
            {
                var query = ctx.talepListele(model.KullaniciId, 0, 10).ToList();
                var adet = query.Count;
              
                    for (var i = 0; i < adet; i++)
                    {
                    TalepList talep = new TalepList();
                    talep.OlusturmaTarihi = query[i].olusturulmaTarihi;
                    talep.TalepDurumAdi = query[i].talepDurumuAdi;
                    talep.TalepDurumId = query[i].talepTuruID;
                    talep.TalepTuruAdi = query[i].talepTuruAdi;
                    talep.TalepTuruId = query[i].talepTuruID;
                    talep.talepID = query[i].talepID;
                        detay.Add(talep);
                    }
                    return Ok(detay);
                
            }
            return Ok();
        }
