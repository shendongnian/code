    var inventory = (from it in _ctx.Items
                        join i in _ctx.Inventories on it.Id equals i.ItemId into iit
    					from i in iit.DefaultIfEmpty()
                        join m in _ctx.MarkedItems on 
                            new {
                                    eancode = (i != null ? i.EANCode : string.Empty),
                                    projectid = (i != null ? i.ProjectId : Guid.Empty)
                                }
                            equals new {
                                eancode = (m != null ? m.EANCode : string.Empty),
                                projectid = (m != null ? m.ProjectId : Guid.Empty)
                            } into im
                        from m in im.DefaultIfEmpty()                    
                        where it.ProjectId == cmp.ProjectId
                        group i by new { 
    						EANCode = it.EANCode, 
    						ItemNo = it.ItemNo, 
    						Name = it.Name, 
    						BaseQty = it.BaseQty, 
    						Price = it.Price, 
    						m = (m != null ? m.EANCode : null)
                        } into lg
                        select new ComparisonBaseModel() {
                                EANCode = lg.Key.EANCode,
                                ItemName = lg.Key.Name,
                                Price = lg.Key.Price,
                                ScanQty = lg.Sum(s => s != null ? s.ScanQty : 0),
                                BaseQty = lg.Key.BaseQty,
                                DiffQty = lg.Sum(s => s != null ? s.ScanQty : 0) - lg.Key.BaseQty,
                                DiffPrice = lg.Key.Price * (lg.Sum(s=> s!= null ? s.ScanQty : 0) - lg.Key.BaseQty),
                                AllTasked = !lg.Any(s=>(s != null && s.InventoryTaskId == null) || s==null),
                                Flagged = lg.Key.m != null
                        }).Where(x=>x.DiffQty != 0);
