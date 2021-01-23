         var randoAgent = new RandomPicker<string>(listofValues);
                foreach (var itemSorgu in formSorgu)
                {
                    var item = randoAgent.PickItem();
                    CrmDonusleri crmEkle = new CrmDonusleri()
                    {
                        Musno = itemSorgu.musno,
                        TelNo = itemSorgu.telno,
                        AtananAgent = item,
                        AradigiBolge = itemSorgu.bolge,
                        AramaTarihi = Convert.ToDateTime(itemSorgu.aratarihi),
                        AtanmaTarihi = DateTime.Now,
                        Ekleyen = itemSorgu.ekleyen,
                        GeriDonusYapildiMi = false,
                        KanalAdi = itemSorgu.kanal,
                        ProgramAdi = itemSorgu.program
                    };
                    DbContext.CrmDonusleri.Add(crmEkle);
                }
                DbContext.SaveChanges();
