      var query = db.DocumentModsums
        .Join(db.Documents,
          data => data.DocumentId,
          d => d.Id,
          (data, doc) => new
          {
            DocumentModsum = data,
            Document = new {
              doc.MethodsOwnershipId,
              doc.DocumentStatusId,
              doc.DocumentTypeId,
              doc.DeletedAt,
              doc.DocumentNumber,
              doc.DocumentRevision,
              doc.DocumentTitle,
              doc.CIN,
              SoaCinNames = db.SummaryOfActions
                              .Join(db.CINs, soa => soa.CINId, cin => cin.Id, (soa, cin) => new { CIN = cin, SOA = soa })
                              .Where(s => s.SOA.DocumentId == doc.Id && s.SOA.DeletedAt == null && s.CIN.DeletedAt == null)
                              .GroupBy(c => c.CIN.CINName)
                              .Select(c => c.Key )}
          }
        )
        .Join(db.Modsums,
          data => data.DocumentModsum.ModsumId,
          m => m.Id,
          (data, mod) => new
          {
            data.DocumentModsum,
            data.Document,
            Modsum = new
            {
              mod.ModsumStatusId,
              mod.ModsumTypeId,
              mod.ModsumNumber,
              mod.ModsumRevision,
              mod.ModsumTitle,
              mod.MSReleaseDate,
              mod.Authority,
              mod.DeletedAt,
              Effectivities = db.ModsumEffectivities
                                             .Where(me => me.ModsumId == mod.Id && me.DeletedAt == null)
                                             .Select(m2 => new ModsumEffectivityVM
                                             {
                                               AircraftFrom = m2.AircraftFromId.ToString(),
                                               AircraftFromId = m2.AircraftFromId,
                                               AircraftTo = m2.AircraftToId.ToString(),
                                               AircraftToId = m2.AircraftToId,
                                               AircraftModelId = m2.AircraftModelId
                                             })
            }
          }
        )
        .Join(db.MethodsOwnerships,
          data => data.Document.MethodsOwnershipId,
          mo => mo.Id,
          (data, mo) => new
          {
            data.DocumentModsum,
            data.Document,
            data.Modsum,
            MethodsOwnership = mo
          })
        .Join(db.DocumentStatus,
          data => data.Document.DocumentStatusId,
          ds => ds.Id,
          (data, ds) => new
          {
            data.DocumentModsum,
            data.Document,
            data.Modsum,
            data.MethodsOwnership,
            DocumentStatus = ds
          })
        .Join(db.DocumentTypes,
          data => data.Document.DocumentTypeId,
          dt => dt.Id,
          (data, dt) => new
          {
            data.DocumentModsum,
            data.Document,
            data.Modsum,
            data.MethodsOwnership,
            data.DocumentStatus,
            DocumentType = dt
          })
        .Join(db.ModsumStatus,
          data => data.Modsum.ModsumStatusId,
          ms => ms.Id,
          (data, ms) => new
          {
            data.DocumentModsum,
            data.Document,
            data.Modsum,
            data.MethodsOwnership,
            data.DocumentStatus,
            data.DocumentType,
            ModsumStatus = ms
          })
        .Join(db.ModsumTypes,
          data => data.Modsum.ModsumTypeId,
          mt => mt.Id,
          (data, ModsumType) => new
          {
            data.DocumentModsum,
            data.Document,
            data.Modsum,
            data.MethodsOwnership,
            data.DocumentStatus,
            data.DocumentType,
            data.ModsumStatus,
            ModsumType,
          })
        .Where(data => data.DocumentModsum.DeletedAt == null
                       && data.Document.DeletedAt == null
                       && data.Modsum.DeletedAt == null
                       && data.MethodsOwnership.DeletedAt == null
                       && data.DocumentStatus.DeletedAt == null
                       && data.DocumentType.DeletedAt == null
                       && data.ModsumStatus.DeletedAt == null
                       && data.ModsumType.DeletedAt == null
        )
        .Select(data => new DocumentVM()
        {
          Id = data.DocumentModsum.Id,
          Status = data.DocumentStatus.Description,
          DocumentNumber = data.Document.DocumentNumber,
          DocumentRevision = data.Document.DocumentRevision,
          DocumentTitle = data.Document.DocumentTitle,
          ModsumNumber = data.Modsum.ModsumNumber,
          ModsumRevision = data.Modsum.ModsumRevision,
          ModsumTitle = data.Modsum.ModsumTitle,
          DocumentType = data.DocumentType.Description,
          MethodsOwnership = data.MethodsOwnership.Description,
          ModsumReleaseDate = data.Modsum.MSReleaseDate,
          ModsumAuthority = data.Modsum.Authority ?? "",
          CreatedAt = data.DocumentModsum.CreatedAt,
          CIN = data.Document.CIN,
          CINList = data.Document.SoaCinNames.ToList(),
          ModsumEffectivity = data.Modsum.Effectivities.ToList()
        }).ToList();
