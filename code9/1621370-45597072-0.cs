    public Page()
    {
        ....
        Battery.AggregateBattery.ReportUpdated += AggregateBattery_ReportUpdated;
    }
    private void AggregateBattery_ReportUpdated(Battery sender, object args)
    {
        var batteryReport = Battery.AggregateBattery.GetReport();
        var percentage = (batteryReport.RemainingCapacityInMilliwattHours.Value / (double)batteryReport.FullChargeCapacityInMilliwattHours.Value);
        if ((percentage == 0.1 || percentage == 0.07) && batteryReport.Status == Windows.System.Power.BatteryStatus.Discharging)
        {
            // Your Code
        }
    }
