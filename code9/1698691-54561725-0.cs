    using System;
    using System.Linq;
    using System.Threading;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Primitives;
    using Timer = System.Timers.Timer;
    namespace MyProject.Classes.Configuration {
        public class MyConfigProvider : ConfigurationProvider {
            private readonly DbContextOptions<MyDbContext> _dbOptions;
            private readonly Timer _reloadTimer = new Timer();
            private ConfigurationReloadToken _reloadToken = new ConfigurationReloadToken();
            public MyConfigProvider(Action<DbContextOptionsBuilder> dbOptionsAction) {
                var builder = new DbContextOptionsBuilder<MyDbContext>();
                dbOptionsAction(builder);
                _dbOptions = builder.Options;
                _reloadTimer.AutoReset = false;
                _reloadTimer.Interval = TimeSpan.FromMinutes(5).TotalMilliseconds;
                _reloadTimer.Elapsed += (s, e) => { OnReload(); };
                
                ChangeToken.OnChange(() => _reloadToken, Load);
            }
            public override void Load() {
                try {
                    using (var db = new MyDbContext(_dbOptions)) {
                        var settings = db.Settings.AsNoTracking().ToList();
                        Data.Clear();
                        foreach (var s in settings) {
                            Data.Add(s.Name, s.Value);
                        }
                    }
                } finally {
                    _reloadTimer.Start();
                }
            }
            
            protected new void OnReload() {
                var previousToken = Interlocked.Exchange(ref _reloadToken, new ConfigurationReloadToken());
                previousToken.OnReload();
            }
        }
    }
