    // Remove deselected disciplines
    entity.ProtocolDisciplines
        .Where(m => !model.SelectedProtocolDisciplines.Contains(m.DisciplineId))
        .ToList()
        .ForEach(m => entity.ProtocolDisciplines.Remove(m));
    // Add new selected disciplines
    var addedDisciplineIds = model.SelectedProtocolDisciplines.Except(entity.ProtocolDisciplines.Select(m => m.DisciplineId));
    db.Disciplines
        .Where(m => addedDisciplineIds.Contains(m.DisciplineId))
        .ToList()
        .ForEach(m => entity.ProtocolDisciplines.Add(m));
