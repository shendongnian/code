    var exercice = await _repositoryExercice.FirstOrDefaultAsync(i => i.IsCurrent);
    var depenses = _repositoryDepense.GetAll()
                    .Where( e => e.ExerciceId.Equals(exercice.Id))
                    .WhereIf(AbpSession.TenantId.HasValue, m => m.TenantId.Value.Equals(AbpSession.TenantId.Value))
                    .ToList();
