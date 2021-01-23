    var query = from r in Ctx.Reg
                select new
                {
                    IdReg = r.Id,
                    ...
                    Status1 = Ctx.RegHist.OrderByDescending(o => o.Id).Any(x=> x.RegId == r.Id && x.Status == 2),
                    Status2 = Ctx.RegHist.OrderByDescending(o => o.Id).Skip(1).Any(x=> x.RegId == r.Id && x.Status == 5)
                };
