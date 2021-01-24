                var source = (from p in _ppmRepository.GetAll()
                             join jt in _jobTypeRepository.GetAll() on p.PpmFkeyInSeq equals jt.Id into jtdata
                             from jt in jtdata.DefaultIfEmpty()
                             join a in _assetRepository.GetAll() on p.PpmFkeyArSeq equals a.Id into aData
                             from a in aData.DefaultIfEmpty()
                             select new BuildingPpmListViewModel
                             {
                                 PpmId = p.Id,
                                 PpBgSeq = p.PpmFkeyBgSeq,
                                 PpmFreq = p.PpmFreq,
                                 PpmNextService = p.PpmNextService,
                                 TotalCost = p.TotalCost,
                                 PpmPeriodUnits = p.PpmPeriodUnits,
                                 PpmFkeyPriDesc = p.PpmFkeyPriDesc,
                                 JtTitle = jt.JtTitle,
                                 AssetId = p.PpmFkeyArSeq,
                                 AssetDescription = a.AssetDescription,
                                 IsDeleted = p.IsDeleted
                             })
                             .Where(x =>  x.PpBgSeq == bldId)
                             .OrderBy(x => x.PpmFreq)
                             .ToList();
