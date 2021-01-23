            var grouped = new[] { data1, data2, data3 }
                .GroupBy(kd => new
                {
                    kd.AsmenysId,
                    kd.Vardas,
                    kd.Pavarde,
                    kd.KlasesId,
                    kd.KlasesPavadinimas,
                    kd.El_pastas,
                    kd.Telefonas,
                    kd.MobilusTelefonas,
                    kd.Adresas
                })
                .Select(g => new KontaktiniaiDuomenysPartialViewModelGrouped
                {
                    AsmenysId = g.Key.AsmenysId,
                    Vardas = g.Key.Vardas,
                    Pavarde = g.Key.Pavarde,
                    Klase = new KlaseModels
                    {
                        Id = g.Key.KlasesId,
                        Pavadinimas = g.Key.KlasesPavadinimas
                    },
                    Kontaktai = new KontaktiniaiDuomenysModel
                    {
                        ElPastas = g.Key.El_pastas,
                        Telefonas = g.Key.Telefonas,
                        MobilusTelefonas = g.Key.MobilusTelefonas,
                        Adresas = g.Key.Adresas
                    },
                    Tevaii = g.Select(kd => new TevoKontaktai { 
                        AsmenysId = kd.TevoAsmenysId,
                         Vardas = kd.TevoVardas,
                         Pavarde = kd.TevoPavarde,
                        Kontaktai = new KontaktiniaiDuomenysModel
                        {
                            ElPastas = kd.TevoElPastas,
                            Telefonas = kd.TevoTelefonas,
                            MobilusTelefonas = kd.TevoMobilusTelefonas,
                            Adresas = kd.TevoAdresas
                        }
                    }).ToList()
                });
