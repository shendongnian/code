    var usefulPacks = Packs.Select(pack => {
        return new Pack() {
            IDAtSource = pack.IDAtSource,
            Equipments = pack.Equipments.Where(equipment => 
                equipment.GenericEquipment.Id == 1
            ).ToList(); 
        };
    }).Where(pack => pack.Equipments.Any()).ToList();
