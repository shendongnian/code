    var query = from medicament in Db.Medicaments
                where medicament.Id == medId
                from mm in Db.MedicamentMedicamentses
                where medicament.Id == mm.MedicamentId || medicament.Id == mm.AnalogId
                select medicament.Id == mm.MedicamentId ? mm.Analog : mm.Medicament;
