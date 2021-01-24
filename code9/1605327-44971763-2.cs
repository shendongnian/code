    using System.Linq;
    var taskResultsWithConfiguration = MachineConfigurations.Select(conf => 
        new { Conf = conf, Task = machineService.GetReports(conf) }).ToList();
    await Task.WhenAll(taskResultsWithConfiguration.Select(pair => pair.Task));
    foreach (var pair in taskResultsWithConfiguration)
          pair.Conf.LastReport = pair.Task.Result;
