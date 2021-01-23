     //Actually they come from the database.
                List<HesapPlanı> hesap = new List<HesapPlanı>();
                hesap.Add(new HesapPlanı { hesapKodu = "100 01 001", hesapAdi = "Kasa" });
                hesap.Add(new HesapPlanı { hesapKodu = "120 01 001", hesapAdi = "CARİ KART" });
                hesap.Add(new HesapPlanı { hesapKodu = "340 01 001", hesapAdi = "AFYON ÖDEMESİ" });
                hesap.Add(new HesapPlanı { hesapKodu = "350 01 001", hesapAdi = "Kasa" });
                hesap.Add(new HesapPlanı { hesapKodu = "360 02 001", hesapAdi = "STOPAJ ÖDEMESİ" });
    
    
         
    
            List<string> kalanList =new List<string>();
            string[] liste1 = "GELEN EFT - CARİ ÖDEMESİ".Split(new char[] { ' ', '-' });
            string[] liste2 = null;
            string sorgu = null;
    
            foreach (var item in hesap.Select(h => h.hesapAdi))
            {
                liste2 = item.Split(new char[] { ' ', '-' });
                var kume = liste1.Intersect(liste2).ToList();
                sorgu = liste2.Intersect(kume).FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(sorgu))
                {
                    kalanList .Add(sorgu);
                }
            }
    
    
            List<HesapPlanı> resultList = new List<HesapPlanı>();
            foreach (var item in kalanList )
            {
                resultList.Add(hesap.Where(m => m.hesapAdi.Contains(item)).FirstOrDefault());
            }
    
    
            Console.WriteLine(resultList.FirstOrDefault().hesapKodu);
