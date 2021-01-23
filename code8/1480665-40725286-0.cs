        using DataAccessPostgreSqlProvider;
        using DomainModel;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        using Microsoft.EntityFrameworkCore;
        using DomainModel.Model;
        
        namespace iConnect.Models.Nest
        {
            public class NestProtectDevices : DomainModelPostgreSqlContext
            {
                public NestProtectDevices(DbContextOptions<DomainModelPostgreSqlContext> options) : base(options)
                {
                }
                public DbSet<Device> Devices { get; set; }
    
            }
    public class Device
    {
                public long DeviceId { get; set; }
                public long UserId { get; set; }
                public int CompanyId { get; set; }
                public long StructureId { get; set; }
                public long WhereId { get; set; }
                public string Name { get; set; }
                public string NameLong { get; set; }
                public bool IsOnline { get; set; }
                public int BatteryHealth { get; set; }
                public int CoAlarmState { get; set; }
                public int SmokeAlarmState { get; set; }
                public string UiColorState { get; set; }
                public bool IsManualTestActive { get; set; }
                public DateTime LastManualTestTime { get; set; }
                public DateTime Timestamp { get; set;}
      }
    }
