    _uow.PartService.Get().Where(p => p.RefCategory.Equals(level2))
                                    .Join(_uow.PartPlantService.Get(),
                                            p => new { p.PartNum, p.Company },
                                            pp => new { pp.PartNum, pp.Company },
                                            (p, pp) => new { Part = p, PartPlant = pp })
                                    .GroupJoin(_uow.VendorService.Get(),
                                            pprc => pprc.PartPlant.VendorNum,
                                            v => v.VendorNum,
                                            (pprc, v) => new { PPRC = pprc, V = v })
                                    .SelectMany(y => y.V.DefaultIfEmpty(),
                                                (x, y) => new { PPRC = x.PPRC, Vendor = y })
                                    .Select(r => new Level2Parts()
                                    {
                                        CompanyCode = r.PPRC.Part.Company,
                                        Description = r.PPRC.Part.PartDescription,
                                        PartNum = r.PPRC.Part.PartNum,
                                        SkuType = r.PPRC.Part.ShortChar01,
                                        VendorCode = r.Vendor.VendorID
                                    })
                                    .Distinct();
