                try
                {
                    var comp = DB.CompaniesGet();
                    stateInjector.CompanyName = comp.company;
                }
                catch (Exception)
                {
                }
                try
                {
                    stateInjector.zones = DB.ZonesGet();
                }
                catch (Exception)
                {
                }
                try
                {
                    var locLog = new PdaLocLog();
                    var locLogger = new PdaLocLogger(DB, locLog);
                    stateInjector.locLogger = locLogger;
                }
                catch (Exception)
                {
                }
