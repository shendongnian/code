                if(k.Id == r1.Rez_kolobezky.Id && r1.Datum_od < DateTime.Now && r1.Datum_do > DateTime.Now)
                {
                    k.Dostupnost = 1;
                }
            }
