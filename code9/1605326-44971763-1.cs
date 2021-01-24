    using System.Linq;
    var taskResultsWithConfiguration = MachineConfigurations.Select(conf => 
        new { Conf = conf, Task = machineService.GetReports(conf) });
    await Task.WhenAll(taskResultsWithConfiguration.Select(pair => pair.Task));
    // OR you can run each task on a different thread, 
    // if machineService.GetReports() involves much synchronous 
    // work at the very start of the method execution. 
    // This will make it faster, but will not support doing work 
    // on the UI thread in that method.
    var taskResultsWithConfiguration = MachineConfigurations.Select(conf => 
        new { Conf = conf, Task = Task.Run(() => machineService.GetReports(conf)) });
    await Task.WhenAll(taskResultsWithConfiguration.Select(pair => pair.Task));
    foreach (var pair in taskResultsWithConfiguration)
          pair.Conf.LastReport = pair.Task.Result;
