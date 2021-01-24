    var device = db.Devices
                 .Join(db.DeviceType,
                     g => g.Id,      // Device Table Id 
                     m => m.Id,      // DeviceType Table Id
                     (g, m) => new { 
                                   Id = g.Id, 
                                   Name = g.Name, 
                                   DeviceTypeName = m.Name 
                  }) 
                 .Where(deviceTyp => deviceTyp.g.ID == Id);     
                 // where condition for g.DeviceTypeId equals m.Id  
