    var config = new ManualConfig();
    config.Add(DefaultConfig.Instance.GetColumnProviders().ToArray());
    config.Add(DefaultConfig.Instance.GetExporters().ToArray());
    config.Add(DefaultConfig.Instance.GetDiagnosers().ToArray());
    config.Add(DefaultConfig.Instance.GetAnalysers().ToArray());
    config.Add(DefaultConfig.Instance.GetJobs().ToArray());
    config.Add(DefaultConfig.Instance.GetValidators().ToArray());
    config.UnionRule = ConfigUnionRule.AlwaysUseGlobal; // Overriding the default
    
    var summary = BenchmarkRunner.Run<TestBench>(config);
    var logger = ConsoleLogger.Default;
    MarkdownExporter.Console.ExportToLog(summary, logger);
    ConclusionHelper.Print(logger, config.GetCompositeAnalyser().Analyse(summary).ToList());
