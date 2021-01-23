    var result = Data()
                 .OrderBy(x=> x.CapacityId)
                 .AsEnumerable()
                 .Select(x => new
                 {
                      Rah_CapacityId = x.Rah_CapacityId,
                      Rah_CapacityName = x.Rah_CapacityName,
                      Rah_St = Enum.GetName(typeof(Domain.Enums.CapacityState), x.Rah_St),
                      Rah_LinesId = x.Rah_LinesId
                 })
                 .AsQueryable();
