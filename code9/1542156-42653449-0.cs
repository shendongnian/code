    var scenarioFormats = from s in this.investment.Scenarios
                          join m in this.keyMappings 
                          on new { Key = s.Key, Level = "DEAL" }
                          equals new { Key = m.Key, Level = m.Level } into sm
                          from scen in sm.DefaultIfEmpty()
                          group new { Scenario = s, scen?.MappingValue } by s.ScenarioNumber into sg
                          select new ScenarioNode
                          {
                              ScenarioNumber = sg.Key,
                              Arguments = sg.Select(s => new ScenarioArgument
                              {
                                  Key = s.Scenario.Key,
                                  Value = s.Scenario.Value,
                                  MappingValue = s.MappingValue
                               }).ToList()
                            };
