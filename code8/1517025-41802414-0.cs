     var result = (from x in Data().ToList()
                  select new
                  {
                      Rah_CapacityId = x.Rah_CapacityId,
                      Rah_CapacityName = x.Rah_CapacityName,
                      Rah_St = Enum.GetName(typeof(Domain.Enums.CapacityState), x.Rah_St),
                      Rah_LinesId = x.Rah_LinesId
                  }).OrderByDescending(o => new { o.Rah_CapacityId });
