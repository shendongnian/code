    var settings = restService.GetSettings();
    this.UCSettings.ExecutionTimes.Clear();
    settings.ExecutionTimes.ForEach(x => this.UCSettings.ExecutionTimes.Add(x));
    this.UCSettings.TableConfigurationLoader = new Setting();
    this.UCSettings.TableConfigurationLoader = settings.Timer.Find(x => x.Name == "TableConfigLoader");
