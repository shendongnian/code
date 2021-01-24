    var dayClasses = (from c in dayProgram
                      group c by c.Hour into cg
                      let cgd = cg.ToDictionary(c => c.RoomId, c => (int?)c.Id)
                      select new {
                          Hour = cg.Key,
                          Room1 = cgd.GetValueOrDefault(1),
                          Room2 = cgd.GetValueOrDefault(2),
                          Room3 = cgd.GetValueOrDefault(3)
                      }).ToDictionary(c => c.Hour, c => c);
