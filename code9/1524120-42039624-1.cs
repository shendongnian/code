    static void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
	{
		PowerStatus pw = SystemInformation.PowerStatus;
		if (e.Mode == Microsoft.Win32.PowerModes.StatusChange)
		{
			if (pw.BatteryLifeRemaining >= 75)
			{
				int bLife = pw.BatteryLifeRemaining;
				MessageBox.Show(bLife.ToString());
			}
		}
	}
