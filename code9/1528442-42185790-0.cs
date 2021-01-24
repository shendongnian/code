    private void RunAnalysis(object sender, RoutedEventArgs e)
    {
        WFPlanningCompliancePluginModel model = DataContext as WFPlanningCompliancePluginModel;
        model.PopulatePatternData.Clear();
            
        // PrintReport.Items.Clear();   // This you can skip if the binding works.
        PrintReport.DataBind(); // This should be enough if the binding works correctly!
        model.Run();
    }
